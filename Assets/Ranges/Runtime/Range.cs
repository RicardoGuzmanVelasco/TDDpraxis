namespace Ranges.Runtime
{
    public struct Range
    {
        public int Min { get; }
        public int Max { get; }
        public int Distance => Max - Min;

        internal Range(int min, int max)
        {
            Min = min;
            Max = max;
        }
        
        public static Range Between(int min, int max)
        {
            return new Range(min, max);
        }
    }
}