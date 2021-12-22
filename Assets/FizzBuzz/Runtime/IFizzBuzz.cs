using JetBrains.Annotations;

namespace FizzBuzz.Runtime
{
    public interface IFizzBuzz
    {
        [Pure, NotNull] string Of(int number);
    }
}