using Mari.Http.Common;

namespace Mari.Http.Requests;

public abstract class PostRequest<TRoute, TQuery, TBody, TResponse> : Request<TRoute, TQuery, TBody, TResponse>
    where TResponse : notnull
{
    protected PostRequest(TRoute? route, TQuery? query, TBody? body) : base(route, query, body)
    {
    }
}
