using Mari.Domain.Common.BaseClasses;
using Mari.Domain.ValueObjects;

namespace Mari.Domain.Entities;

public class Issue : EntityBase<Guid>
{
    private Issue()
    {
    }

    public Issue(IssueTitle title, IssueLink link)
    {
        Title = title;
        Link = link;
    }

    public IssueTitle Title { get; private set; } = null!;
    public IssueLink Link { get; private set; } = null!;

    public void ChangeTitle(IssueTitle title)
    {
        Title = title;
    }

    public void ChangeLink(IssueLink link)
    {
        Link = link;
    }

    public static Issue Create(IssueTitle title, IssueLink link) => new Issue
    {
        Title = title,
        Link = link
    };
}
