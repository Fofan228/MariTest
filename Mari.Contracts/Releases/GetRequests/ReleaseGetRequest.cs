using Mari.Contracts.Common.Routes.Server;
using Mari.Contracts.Releases.Responce;
using Mari.Http.Common.Classes;
using Mari.Http.Models;
using Mari.Http.Requests;
using static Mari.Contracts.Releases.GetRequests.ReleaseGetRequest;

namespace Mari.Contracts.Releases.GetRequests;

public class ReleaseGetRequest : GetRequest<Route, EmptyQuery, ReleaseResponse>
{

    public const string ConstRouteTemplate = $"{ServerRoutes.Controllers.Release}/{{{nameof(Route.id)}}}";
    public override string RouteTemplate => $"{ServerRoutes.Controllers.Release}/{RouteParams!.id}";
    
    public ReleaseGetRequest(
        Route route)
        : base(route, new())
    {
    }
    

    public record Route(Guid id) : RequestRoute;
}
