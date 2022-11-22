using Mari.Http.Common.Classes;

namespace Mari.Http.Models;

public record EmptyRoute : RequestRoute
{
    public override string GetRoute(string RouteTemplate) => RouteTemplate;
}
