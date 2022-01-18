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

        #region Equality
        public static bool operator ==(Range r1, Range r2)
        {
            return r1.Equals(r2);
        }

        public static bool operator !=(Range r1, Range r2)
        {
            return !(r1 == r2);
        }
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