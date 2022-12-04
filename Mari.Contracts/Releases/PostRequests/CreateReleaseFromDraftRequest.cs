using Mari.Contracts.Common.Routes.Server;
using Mari.Http.Common.Classes;
using Mari.Http.Models;
using Mari.Http.Requests;
using static Mari.Contracts.Releases.PostRequests.CreateReleaseFromDraftRequest;

namespace Mari.Contracts.Releases.PostRequests;

public class CreateReleaseFromDraftRequest : PostRequest<Route, EmptyQuery, EmptyBody, VoidResponse>
{
    public const string ConstRouteTemplate = $"{ServerRoutes.Controllers.Release}/from_draft/{{ReleaseId}}";
    public override string RouteTemplate => $"{ServerRoutes.Controllers.Release}/from_draft/{RouteParams.ReleaseId}";

    public CreateReleaseFromDraftRequest(Route body) : base(body, new(), new())
    {
    }

    public record Route(Guid ReleaseId) : RequestRoute;
}
