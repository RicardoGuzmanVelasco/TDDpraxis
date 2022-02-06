using System;
using System.Collections.Generic;
using System.Linq;

namespace RomanNumerals.Runtime
{
    internal record RomanSymbol
    {
        #region Fixed
        internal static readonly Dictionary<char, int> Symbols = new Dictionary<char, int>
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

        #region Constructor
        public RomanSymbol(char symbol)
        {
            if(!IsValid(symbol))
                throw new ArgumentOutOfRangeException();

            this.symbol = symbol;
        }
        #endregion

        #region Operator overloading
        public static implicit operator int(RomanSymbol rs)
        {
            return Symbols[rs.symbol];
        }
        
        public static implicit operator RomanSymbol(char c)
        {
            return new RomanSymbol(c);
        }


        public static implicit operator string(RomanSymbol rs)
        {
            return rs.ToString();
        }

        public override string ToString()
        {
            return symbol.ToString();
        }

        public static bool operator >=(RomanSymbol r1, RomanSymbol r2)
        {
            return !(r1 < r2);
        }

        public static bool operator <=(RomanSymbol r1, RomanSymbol r2)
        {
            return !(r1 > r2);
        }

        public static bool operator >(RomanSymbol r1, RomanSymbol r2)
        {
            return SymbolIndex(r1) > SymbolIndex(r2);
        }

        public static bool operator <(RomanSymbol r1, RomanSymbol r2)
        {
            return SymbolIndex(r1) < SymbolIndex(r2);
        }
        #endregion

        #region SupportMethods
        internal static bool IsValid(char symbol)
        {
            return Symbols.ContainsKey(symbol);
        }

        internal static RomanSymbol ClosestSymbolTo(int number)
        {
            return Symbols.Last(symbol => symbol.Value <= number).Key;
        }

        static int SymbolIndex(RomanSymbol rs)
        {
            return Symbols.Keys.ToList().IndexOf(rs.symbol);
        }
        #endregion
    }
}