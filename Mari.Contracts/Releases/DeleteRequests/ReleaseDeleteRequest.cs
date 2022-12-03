using Mari.Contracts.Common.Routes.Server;
using Mari.Http.Common.Classes;
using Mari.Http.Models;
using Mari.Http.Requests;

namespace Mari.Contracts.Releases.DeleteRequests;

public class ReleaseDeleteRequest: DeleteRequest<ReleaseDeleteRequest.Route, EmptyQuery, EmptyBody>
{
    public const string ConstRouteTemplate = $"{ServerRoutes.Controllers.Release}/delete/{{{nameof(Route.id)}}}";
    public override string RouteTemplate => $"{ServerRoutes.Controllers.Release}/delete/{RouteParams!.id}";

    public ReleaseDeleteRequest(Route route) : base(route, new())
    {
    }

    public record Route(
            Guid id)
        : RequestRoute;
}
