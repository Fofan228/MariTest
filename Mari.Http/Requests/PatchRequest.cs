using Mari.Http.Common.Classes;
using Mari.Http.Common.Interfaces;

namespace Mari.Http.Requests;

public abstract class PatchRequest<TRoute, TQuery, TBody, TResponse> : Request<TRoute, TQuery, TBody, TResponse>
    where TRoute : IRequestRoute
    where TQuery : IRequestQuery
    where TBody : IRequestBody
    where TResponse : notnull
{
    protected PatchRequest(TRoute route, TQuery query, TBody body) : base(route, query, body)
    {
    }
}
