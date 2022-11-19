using Mari.Http.Common;

namespace Mari.Http.Requests;

public abstract class PatchRequest<TRoute, TQuery, TBody, TResponse> : Request<TRoute, TQuery, TBody, TResponse>
    where TResponse : notnull
{
    protected PatchRequest(TRoute? route, TQuery? query, TBody? body) : base(route, query, body)
    {
    }
}
