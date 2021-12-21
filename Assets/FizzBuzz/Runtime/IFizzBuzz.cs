using JetBrains.Annotations;

namespace FizzBuzz.Runtime
{
    public interface IFizzBuzz
    {
        [Pure] string Of(int number);
    }
}