namespace FizzBuzz.Runtime
{
    internal static class FizzBuzzExtensions
    {
        public static bool IsDivisibleBy(this int multipleWannabe, int divisor)
        {
            return multipleWannabe % divisor == 0;
        }
    }
}