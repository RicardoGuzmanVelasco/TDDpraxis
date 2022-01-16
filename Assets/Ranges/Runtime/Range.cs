using System;

namespace Ranges.Runtime
{
    public readonly struct Range
    {
        public static Range Zero = new Range();

        public int Min { get; }
        public int Max { get; }
        
        public int Distance => Max - Min;
        public bool IsEmpty => Distance == 0;

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
    }
}