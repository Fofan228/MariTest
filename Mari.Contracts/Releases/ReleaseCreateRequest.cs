using Mari.Contracts.Common.Routes.Server;
using Mari.Http.Common.Classes;
using Mari.Http.Models;
using Mari.Http.Requests;
using static Mari.Contracts.Releases.ReleaseCreateRequest;

namespace Mari.Contracts.Releases;

public class ReleaseCreateRequest : PostRequest<EmptyRoute, EmptyQuery, Body, VoidResponse>
{
    public const string ConstRouteTemplate = $"{ServerRoutes.Controllers.Release}";
    public override string RouteTemplate => ConstRouteTemplate;

    public ReleaseCreateRequest(Body body) : base(new(), new(), body)
    {
    }

    public record Body(
        string MainIssue,
        DateTime CompleteDate,
        string PlatformName,
        string Version,
        string Description)
        : RequestBody;
}
