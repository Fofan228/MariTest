using Mari.Domain.Common.BaseClasses;

namespace Mari.Domain.ValueObjects;

public record IssueLink(string Value) : ValueObjectBase
{
    //TODO Переделать регулярку, если надо
    public const string Pattern = @"(http|ftp|https):\/\/([\w_-]+(?:(?:\.[\w_-]+)+))([\w.,@?^=%&:\/~+#-]*[\w@?^=%&\/~+#-])";
    public static implicit operator string(IssueLink value) => value.ToString();
    public override string ToString() => Value;
}
