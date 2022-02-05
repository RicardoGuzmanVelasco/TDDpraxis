using System;
using System.Collections.Generic;

namespace RomanNumerals.Runtime
{
    internal record RomanSymbol
    {
        #region Fixed
        static readonly Dictionary<char, int> Symbols= new Dictionary<char, int>
        {
            ['I'] = 1,
            ['V'] = 5,
            ['X'] = 10,
            ['L'] = 50,
            ['C'] = 100,
            ['D'] = 500,
            ['M'] = 1000,
        };
        #endregion
            
        readonly char symbol;

        public RomanSymbol(char symbol)
        {
            if(!IsValid(symbol))
                throw new ArgumentOutOfRangeException();
                
            this.symbol = symbol;
        }

        public static implicit operator int(RomanSymbol rs)
        {
            return Symbols[rs.symbol];
        }

        internal static bool IsValid(char symbol)
        {
            return Symbols.ContainsKey(symbol);
        }
    }
}