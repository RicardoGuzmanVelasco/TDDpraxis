using System;
using JetBrains.Annotations;

namespace FizzBuzz.Runtime
{
    public class FizzBuzzNumber
    {
        [Pure]
        public string Of(int number)
        {
            if(number < 1)
                throw new ArgumentOutOfRangeException();

            var result = number switch
            {
                var n when n % 3 == 0 && n % 5 != 0 => "Fizz",
                var n when n % 5 == 0 && n % 3 != 0  => "Buzz",
                var n when n % 3 == 0 && n % 5 == 0 => "Fizz Buzz",
                _ => number.ToString()
            };

            return result;
        }
    }
}