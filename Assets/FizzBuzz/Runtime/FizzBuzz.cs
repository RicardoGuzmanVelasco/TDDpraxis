using System;
using JetBrains.Annotations;

namespace FizzBuzz.Runtime
{
    public class FizzBuzzNumber
    {
        const string Fizz = "Fizz";
        const string Buzz = "Buzz";

        [Pure]
        public string Of(int number)
        {
            if(number < 1)
                throw new ArgumentOutOfRangeException();

            var result = number switch
            {
                var n when n % 3 == 0 => Fizz,
                var n when n % 5 == 0 => Buzz,
                _ => number.ToString()
            };

            return result;
        }
    }
}