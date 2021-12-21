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

            return number switch
            {
                3 => Fizz,
                5 => Buzz,
                _ => number.ToString()
            };
        }
    }
}