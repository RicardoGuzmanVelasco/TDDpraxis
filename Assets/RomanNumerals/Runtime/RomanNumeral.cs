using System;
using System.Linq;

namespace RomanNumerals.Runtime
{
    public struct RomanNumeral
    {
        public static RomanNumeral I { get; } = new RomanNumeral();
        
        public RomanNumeral(string s)
        {
            if(!s.All(IsRomanSymbol))
                throw new ArgumentOutOfRangeException();
        }

        static bool IsRomanSymbol(char symbol)
        {
            return symbol is 'I' or 'V' or 'X' or 'L' or 'C' or 'D' or 'M';
        }
    }
}