using Mari.Contracts.Common.Routes.Server;
using Mari.Http.Common.Classes;
using Mari.Http.Models;
using Mari.Http.Requests;
using static Mari.Contracts.Releases.PostRequests.ReleaseUpdateRequest;

namespace Mari.Contracts.Releases.PostRequests;

public class ReleaseUpdateRequest : PostRequest<EmptyRoute, EmptyQuery, Body, VoidResponse>
{

    public const string ConstRouteTemplate = $"{ServerRoutes.Controllers.Release}/update";
    public override string RouteTemplate => ConstRouteTemplate;

    public ReleaseUpdateRequest(Body body) : base(new(), new(), body)
    {
    }
    public record Body(
        Guid id,
        string platformName,
        string version,
        string releaseStatus,
        DateTime updateDate,
        DateTime completeDate,
        string description,
        Uri mainIssue) : RequestBody;
}
