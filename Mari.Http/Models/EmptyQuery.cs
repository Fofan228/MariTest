using Mari.Http.Common.Classes;
using Mari.Http.Common.Interfaces;

namespace Mari.Http.Models;

public record EmptyQuery : RequestQuery
{
    public override string GetQueryString() => string.Empty;
}
