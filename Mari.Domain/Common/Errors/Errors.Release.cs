using ErrorOr;

namespace Mari.Domain.Common;

public partial class Errors
{
    public class Release
    {
        public static readonly Error VersionMustBeGreaterThanCurrent = Error.Validation(
            description: "Release version must be greater than current version");

        public static readonly Error CompleteDateMustBeGreaterThanCurrent = Error.Validation(
            description: "Release complete date must be greater than current date");
    }
}
