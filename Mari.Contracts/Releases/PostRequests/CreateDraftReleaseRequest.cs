using Mari.Contracts.Common.Routes.Server;
using Mari.Http.Common.Classes;
using Mari.Http.Models;
using Mari.Http.Requests;
using static Mari.Contracts.Releases.PostRequests.CreateDraftReleaseRequest;

namespace Mari.Contracts.Releases.PostRequests;

public class CreateDraftReleaseRequest : PostRequest<EmptyRoute, EmptyQuery, Body, VoidResponse>
{
    public const string ConstRouteTemplate = $"{ServerRoutes.Controllers.Release}/draft";
    public override string RouteTemplate => ConstRouteTemplate;

    public CreateDraftReleaseRequest(Body body) : base(new(), new(), body)
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
