using System;
using System.Linq;

namespace RomanNumerals.Runtime
{
    public record RomanNumeral
    {
        readonly string symbols;

        #region Nested types
        #endregion

        #region Constructors
        public RomanNumeral() : this("I")
        {
        }

        public RomanNumeral(string symbols)
        {
            if(!symbols.All(RomanSymbol.IsValid))
                throw new ArgumentOutOfRangeException();

            this.symbols = symbols;
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
            if(r.symbols.Length != 1)
                throw new NotImplementedException();

            return new RomanSymbol(r.symbols.First());
        }
        #endregion
    }
}