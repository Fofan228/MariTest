using Mari.Http.Common;

namespace Mari.Http.Requests;

public abstract class DeleteRequest<TRoute, TQuery, TResponse> : Request<TRoute, TQuery, object, TResponse>
    where TResponse : notnull
{
    protected DeleteRequest(TRoute? route, TQuery? query) : base(route, query, null)
    {
    }
}
