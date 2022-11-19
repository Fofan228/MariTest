using ErrorOr;

namespace Mari.Domain.Common.Errors;

public partial class Errors
{
    public class Comment
    {
        public static readonly Error BlockedBySystem = Error.Failure(description: "Comment is blocked by system");
    }
}
