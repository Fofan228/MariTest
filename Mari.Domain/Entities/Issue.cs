using Mari.Domain.Common.BaseClasses;
using Mari.Domain.ValueObjects;

namespace Mari.Domain.Entities;

public class Issue : EntityBase<Guid>
{
    public Issue()
    {
    }

    public Issue(Guid id, IssueTitle title, IssueLink link) : base(id)
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
}