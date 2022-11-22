using Mari.Http.Common.Classes;
using Mari.Http.Common.Interfaces;
using Mari.Http.Models;

namespace Mari.Http.Requests;

public abstract class GetRequest<TRoute, TQuery, TResponse> : Request<TRoute, TQuery, EmptyBody, TResponse>
    where TRoute : IRequestRoute
    where TQuery : IRequestQuery
    where TResponse : notnull
{
    protected GetRequest(TRoute route, TQuery query) : base(route, query, new())
    {
    }
}
