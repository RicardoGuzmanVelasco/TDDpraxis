using System;

namespace FizzBuzz.Runtime
{
    public class FizzBuzzNumber : IFizzBuzz
    {
        public string Of(int number)
        {
            if(number < 1)
                throw new ArgumentOutOfRangeException();

            var result = number switch
            {
                var n when n.IsDivisibleBy(3) && !n.IsDivisibleBy(5) => "Fizz",
                var n when n.IsDivisibleBy(5) && !n.IsDivisibleBy(3) => "Buzz",
                var n when n.IsDivisibleBy(15) => "Fizz Buzz",
                _ => number.ToString()
            };

            return result;
        }
    }
}