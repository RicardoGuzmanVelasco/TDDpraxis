using System;
using System.Linq;

namespace RomanNumerals.Runtime
{
    public record RomanNumeral
    {
        readonly string symbols;

        #region FactoryMethods
        public static RomanNumeral I { get; } = new RomanNumeral("I");
        #endregion

        #region Constructors
        public RomanNumeral() : this("I") { }
        public RomanNumeral(string symbols)
        {
            if(!symbols.All(IsRomanSymbol))
                throw new ArgumentOutOfRangeException();

            this.symbols = symbols;
        }
        #endregion

        #region SupportMethods
        static bool IsRomanSymbol(char symbol)
        {
            return symbol is 'I' or 'V' or 'X' or 'L' or 'C' or 'D' or 'M';
        }
        #endregion
    }
}