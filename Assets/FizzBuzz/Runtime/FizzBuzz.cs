using System;
using JetBrains.Annotations;

namespace FizzBuzz.Runtime
{
    public class FizzBuzzNumber
    {
        const string Fizz = "Fizz";

        [Pure]
        public string Of(int number)
        {
            if(number < 1)
                throw new ArgumentOutOfRangeException();
            
            return number == 3 ? Fizz : number.ToString();
        }
    }
}