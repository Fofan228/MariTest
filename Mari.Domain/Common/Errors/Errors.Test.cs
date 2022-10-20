using ErrorOr;

namespace Mari.Domain.Common;

public static partial class Errors
{
    public static class Test
    {
        public static Error TestError => Error.Custom((int)ErrorType.Unexpected, "TestError", "This is a test error.");
    }
}