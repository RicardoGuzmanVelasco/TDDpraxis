namespace FizzBuzz.Runtime
{
    public class FizzBuzzWordTransmutator : IFizzBuzz
    {
        readonly int multipleOf;
        readonly string transmuteTo;

        public FizzBuzzWordTransmutator(int multipleOf, string transmuteTo)
        {
            this.multipleOf = multipleOf;
            this.transmuteTo = transmuteTo;
        }

        public string Of(int number)
        {
            return number.IsDivisibleBy(multipleOf)
                ? transmuteTo
                : string.Empty;
        }
    }
}