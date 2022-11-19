using Mari.Http.Common;
using Mari.Http.Models;

namespace Mari.Http.Requests;

public abstract class PutRequest<TRoute, TQuery, TBody> : Request<TRoute, TQuery, TBody, VoidResponse>
{
    protected PutRequest(TRoute? route, TQuery? query, TBody? body) : base(route, query, body)
    {
    }
}
