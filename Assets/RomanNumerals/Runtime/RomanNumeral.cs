using System;
using System.Linq;

namespace RomanNumerals.Runtime
{
    public record RomanNumeral
    {
        readonly string symbols;

        #region SupportMethods
        static bool IsRomanSymbol(char symbol)
        {
            return symbol is 'I' or 'V' or 'X' or 'L' or 'C' or 'D' or 'M';
        }
        #endregion

        #region Constructors
        public RomanNumeral() : this("I")
        {
        }

        public RomanNumeral(string symbols)
        {
            if(!symbols.All(IsRomanSymbol))
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
            return r.symbols switch
            {
                "I" => 1,
                "V" => 5,
                "X" => 10,
                "L" => 50,
                "C" => 100,
                "D" => 500,
                "M" => 1000,
                _ => throw new InvalidOperationException()
            };
        }
        #endregion
    }
}