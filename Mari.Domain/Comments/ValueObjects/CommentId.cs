using Mari.Domain.Common.Models;

namespace Mari.Domain.Comments.ValueObjects;

public record CommentId : ValueObjectWrapper<Guid>
{
    public static CommentId Create(Guid value)
    {
        return new CommentId(value);
    }

    public static CommentId Default { get; } = new CommentId(default(Guid));

    private CommentId(Guid Value) : base(Value)
    {
    }
}
