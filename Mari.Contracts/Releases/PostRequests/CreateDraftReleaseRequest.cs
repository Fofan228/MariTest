using Mari.Contracts.Common.Routes.Server;
using Mari.Http.Common.Classes;
using Mari.Http.Models;
using Mari.Http.Requests;

namespace Mari.Contracts.Releases.PostRequests;

public class CreateDraftReleaseRequest : PostRequest<VoidResponse>
{
    public const string ConstRouteTemplate = $"{ServerRoutes.Controllers.Release}/draft";
    public override string RouteTemplate => ConstRouteTemplate;

    public CreateDraftReleaseRequest(Body body) : base(body: body)
    {
    }

    public record Body(
        string? MainIssue,
        DateTime? CompleteDate,
        string? PlatformName,
        int? VersionMajor,
        int? VersionMinor,
        int? VersionPatch,
        string? Description)
        : RequestBody;
}
