using System;

namespace Ranges.Runtime
{
    public readonly struct Range
    {
        public static Range Zero = new Range();

        public int Min { get; }
        public int Max { get; }
        
        public int Length => Max - Min;
        public bool IsEmpty => Length == 0;

        internal Range(int min, int max)
        {
            if(min > max)
                throw new ArgumentOutOfRangeException();
            
            Min = min;
            Max = max;
        }
        
        public static Range Between(int min, int max)
        {
            return new Range(min, max);
        }
        
        public bool Includes(Range other)
        {
            return Includes(other.Min) && Includes(other.Max);
        }
        
        public bool Includes(double number)
        {
            return number >= Min && number <= Max;
        }

        #region Equality
        public static bool operator ==(Range r1, Range r2)
        {
            return r1.Equals(r2);
        }

        public static bool operator !=(Range r1, Range r2)
        {
            return !(r1 == r2);
        }
        
        public bool Equals(Range other)
        {
            return Min == other.Min && Max == other.Max;
        }

        public override bool Equals(object obj)
        {
            return obj is Range other && Equals(other);
        }

        public override int GetHashCode() => unchecked (Min * 397) ^ Max;
        #endregion
        
        #region Order
        public static bool operator <(Range r1, Range r2)
        {
            return r1.Max <= r2.Min;
        }

        public static bool operator >(Range r1, Range r2)
        {
            return r1.Min >= r2.Max;
        }
        #endregion
    }
}