using Mari.Contracts.Common.Routes.Server;
using Mari.Http.Common.Classes;
using Mari.Http.Requests;

namespace Mari.Contracts.Releases.PutRequests;

public class UpdateReleaseRequest : PutRequest
{
    public const string ConstRouteTemplate = $"{ServerRoutes.Controllers.Release}";
    public override string RouteTemplate => ConstRouteTemplate;

    public UpdateReleaseRequest(Body body) : base(body: body)
    {
    }

    public record Body(
        Guid Id,
        int VersionMajor,
        int VersionMinor,
        int VersionPatch,
        string PlatformName,
        int Status,
        DateTime CompleteDate,
        string MainIssue,
        string Description)
        : RequestBody;
}
