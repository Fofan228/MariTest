using Mari.Domain.Common.Models;

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

    public string Link { get; private set; }
    public string? Title { get; private set; }

    public void ChangeLink(string link)
    {
        Link = link;
    }

    public void SetTitle(string title)
    {
        Title = title;
    }

    public void RemoveTitle()
    {
        Title = null;
    }
}
