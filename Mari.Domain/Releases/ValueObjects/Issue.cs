using Mari.Domain.Common.Models;
using Mari.Domain.Users.ValueObjects;

namespace Mari.Domain.Releases.ValueObjects;

public record Issue : ValueObject
{
    public const string LinkPattern = @"(http|ftp|https):\/\/([\w_-]+(?:(?:\.[\w_-]+)+))([\w.,@?^=%&:\/~+#-]*[\w@?^=%&\/~+#-])";

    public static Issue Create(string link)
    {
        return new Issue(link);
    }

    private Issue(string link)
    {
        Link = link;
    }

    public string Link { get; init; }
}
