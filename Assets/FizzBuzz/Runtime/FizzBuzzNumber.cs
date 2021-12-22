using System;
using JetBrains.Annotations;

namespace FizzBuzz.Runtime
{
    public class FizzBuzzNumber : IFizzBuzz
    {
        readonly IFizzBuzz fizz = new FizzBuzzWordTransmutator(3, "Fizz");
        readonly IFizzBuzz buzz = new FizzBuzzWordTransmutator(5, "Buzz");

        public string Of(int number)
        {
            if(number < 1)
                throw new ArgumentOutOfRangeException();

            return SpecialWordOrNull(number) ?? number.ToString();
        }
        
        #region Support methods
        [CanBeNull] string SpecialWordOrNull(int number)
        {
            var fizzWord = fizz.Of(number);
            var buzzWord = buzz.Of(number);

            var spaceInBetween = SpaceIfFizzBuzz();

            var word = fizzWord + spaceInBetween + buzzWord;
            return word != string.Empty
                ? word
                : null;

            string SpaceIfFizzBuzz()
            {
                var spaceInBetween = string.Empty;
                
                if(fizzWord != string.Empty && buzzWord != string.Empty)
                    spaceInBetween = " ";
                
                return spaceInBetween;
            }
        }
        #endregion

    }
}