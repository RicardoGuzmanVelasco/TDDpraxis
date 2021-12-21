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
            
            return number.ToString();
        }
    }
}