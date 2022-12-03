using System.Net.Http.Json;
using Mari.Http.Common.Interfaces;

namespace Mari.Http.Common.Classes;

public abstract class Request<TRoute, TQuery, TBody, TResponse> : IRequest<TResponse>
    where TRoute : IRequestRoute
    where TQuery : IRequestQuery
    where TBody : IRequestBody
    where TResponse : notnull
{
    protected Request(TRoute route, TQuery query, TBody body)
    {
        RouteParams = route;
        QueryParams = query;
        BodyContent = body;
    }

    public TRoute RouteParams { get; set; }
    public TQuery QueryParams { get; set; }
    public TBody BodyContent { get; set; }

    public abstract string RouteTemplate { get; }

    public string GetRouteWithParams() => RouteParams.GetRoute(RouteTemplate);
    public string GetQueryString() => QueryParams.GetQueryString();
    public JsonContent? GetBodyContent() => BodyContent.GetBody();
}
