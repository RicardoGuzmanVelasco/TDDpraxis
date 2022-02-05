using System;

namespace RomanNumerals.Runtime
{
    public struct RomanNumeral
    {
        public RomanNumeral(string s)
        {
            if(s.Contains("a"))
                throw new ArgumentOutOfRangeException();
        }

        public static RomanNumeral I { get; } = new RomanNumeral();
    }
}