using Mari.Http.Common.Classes;
using Mari.Http.Common.Interfaces;
using Mari.Http.Models;

namespace Mari.Http.Requests;

public abstract class PutRequest<TRoute, TQuery, TBody> : Request<TRoute, TQuery, TBody, VoidResponse>
    where TRoute : IRequestRoute
    where TQuery : IRequestQuery
    where TBody : IRequestBody
{
    protected PutRequest(TRoute route, TQuery query, TBody body) : base(route, query, body)
    {
    }
}
