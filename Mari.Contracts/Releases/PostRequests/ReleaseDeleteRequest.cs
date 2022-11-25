using Mari.Contracts.Common.Routes.Server;
using Mari.Http.Common.Classes;
using Mari.Http.Models;
using Mari.Http.Requests;
using static Mari.Contracts.Releases.PostRequests.ReleaseDeleteRequest;

namespace Mari.Contracts.Releases.PostRequests;

public class ReleaseDeleteRequest: PostRequest<Route, EmptyQuery, EmptyBody, VoidResponse>
{
    public const string ConstRouteTemplate = $"{ServerRoutes.Controllers.Release}/delete/{{{nameof(Route.id)}}}";
    public override string RouteTemplate => $"{ServerRoutes.Controllers.Release}/delete/{RouteParams!.id}";

    public ReleaseDeleteRequest(Route route) : base(route, new(), new())
    {
    }

    public record Route(
            Guid id)
        : RequestRoute;
}
