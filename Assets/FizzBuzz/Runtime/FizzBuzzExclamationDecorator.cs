namespace FizzBuzz.Runtime
{
    public class FizzBuzzExclamationDecorator : IFizzBuzz
    {
        readonly IFizzBuzz decorated;
        
        public FizzBuzzExclamationDecorator(IFizzBuzz decorated)
        {
            this.decorated = decorated;
        }

        public string Of(int number)
        {
            var result = decorated.Of(number);

            if(result != number.ToString())
                result += "!";

            return result;
        }
    }
}