using Mari.Http.Common;

namespace Mari.Http.Requests;

public abstract class GetRequest<TRoute, TQuery, TResponse> : Request<TRoute, TQuery, object, TResponse>
    where TResponse : notnull
{
    protected GetRequest(TRoute? route, TQuery? query) : base(route, query, null)
    {
    }
}
