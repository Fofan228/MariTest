using Mari.Domain.Common.Models;
using Mari.Domain.Users.ValueObjects;

namespace Mari.Domain.Releases.ValueObjects;

public record Issue : ValueObject
{
    public const string LinkPattern = @"(http|ftp|https):\/\/([\w_-]+(?:(?:\.[\w_-]+)+))([\w.,@?^=%&:\/~+#-]*[\w@?^=%&\/~+#-])";
    public const string TitlePattern = @"^[^\d\W]+.*";

    public static Issue Create(string link, string? title = null)
    {
        return new Issue(link, title);
    }

    private Issue(string link, string? title = null)
    {
        Link = link;
        Title = title;
    }

    public string Link { get; init; }
    public string? Title { get; init; }
    public static void A()
    {
        var a = Username.Create("a");
        var b = a with { Value = "b" };
    }
}
