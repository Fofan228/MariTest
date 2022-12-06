using Mari.Contracts.Common.Routes.Server;
using Mari.Http.Common.Classes;
using Mari.Http.Models;
using Mari.Http.Requests;
using static Mari.Contracts.Releases.PostRequests.CreateReleaseFromDraftRequest;

namespace Mari.Contracts.Releases.PostRequests;

public class CreateReleaseFromDraftRequest : PostRequest<VoidResponse>
{
    private new Route RouteParams => (Route)base.RouteParams;

    public const string ConstRouteTemplate = $"{ServerRoutes.Controllers.Release}/from_draft/{{ReleaseId}}";
    public override string RouteTemplate => ConstRouteTemplate;

    public CreateReleaseFromDraftRequest(Route route) : base(route: route)
    {
    }

    public record Route(Guid ReleaseId) : RequestRoute;
}
