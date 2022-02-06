using System;
using System.Collections.Generic;
using System.Linq;

namespace RomanNumerals.Runtime
{
    public record RomanNumeral
    {
        readonly string symbols;

        IEnumerable<RomanSymbol> RomanSymbols => symbols.Select(c => new RomanSymbol(c));


        #region SupportMethods
        internal IEnumerable<string> ClusterSymbols()
        {
            var originalSymbols = RomanSymbols.ToList();
            originalSymbols.Reverse();

            var clusterSymbols = new List<string>();
            while(originalSymbols.Count > 1)
                if(originalSymbols[0] <= originalSymbols[1])
                {
                    clusterSymbols.Add(originalSymbols[0]);
                    originalSymbols.RemoveAt(0);
                }
                else
                {
                    clusterSymbols.Add(originalSymbols[1].ToString() + originalSymbols[0]);
                    originalSymbols.RemoveAt(0);
                    originalSymbols.RemoveAt(0);
                }

            if(originalSymbols.Any())
                clusterSymbols.Add(originalSymbols.First());
            return clusterSymbols;
        }
        #endregion

        #region Constructors
        public RomanNumeral() : this("I")
        {
        }

        public RomanNumeral(string symbols)
        {
            AssertSymbolsAreValid(symbols);
            AssertNoAdditiveNotation(symbols);

            this.symbols = symbols;
        }

        static void AssertSymbolsAreValid(string symbols)
        {
            if(!symbols.All(RomanSymbol.IsValid))
                throw new ArgumentOutOfRangeException();
        }

        static void AssertNoAdditiveNotation(string symbols)
        {
            if(HasFourOrMoreRepeatedChainingSymbols())
                throw new NotSupportedException("Additive notation is not supported");

            bool HasFourOrMoreRepeatedChainingSymbols()
            {
                var sameSymbolCombo = 0;

                for(var i = 1; i < symbols.Length; i++)
                {
                    sameSymbolCombo++;
                    if(symbols[i] != symbols[i - 1])
                        sameSymbolCombo = 0;

                    if(sameSymbolCombo >= 3)
                        return true;
                }

                return false;
            }
        }
        #endregion

        #region Operator overloading
        public override string ToString()
        {
            return symbols;
        }

        public static implicit operator RomanNumeral(string symbols)
        {
            return new RomanNumeral(symbols);
        }

        public static implicit operator int(RomanNumeral r)
        {
            return r.ToInt();
        }

        int ToInt()
        {
            var clusters = ClusterSymbols();

            var addingSymbols = clusters.Where(s => s.Length == 1).Select(s => s.First());

            return addingSymbols.Sum(c => new RomanSymbol(c));
        }
        #endregion
    }
}