using System;

namespace FizzBuzz.Runtime
{
    public class FizzBuzzNumber : IFizzBuzz
    {
        readonly IFizzBuzz fizz = new FizzBuzzMultipleTransmutator(3, "Fizz");
        readonly IFizzBuzz buzz = new FizzBuzzMultipleTransmutator(5, "Buzz");
        readonly IFizzBuzz fizzbuzz = new FizzBuzzMultipleTransmutator(15, "Fizz Buzz");

        public string Of(int number)
        {
            if(number < 1)
                throw new ArgumentOutOfRangeException();

            var result = number switch
            {
                var n when n.IsDivisibleBy(3) && !n.IsDivisibleBy(5) => fizz.Of(number),
                var n when n.IsDivisibleBy(5) && !n.IsDivisibleBy(3) => buzz.Of(number),
                var n when n.IsDivisibleBy(15) => fizzbuzz.Of(number),
                _ => number.ToString()
            };

            return result;
        }

        
        

    }
}