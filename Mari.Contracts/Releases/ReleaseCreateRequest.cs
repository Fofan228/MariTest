using Mari.Contracts.Common.Routes.Server;
using Mari.Http.Models;
using Mari.Http.Requests;
using static Mari.Contracts.Releases.ReleaseCreateRequest;

namespace Mari.Contracts.Releases;

public class ReleaseCreateRequest : PostRequest<object, object, Body, VoidResponse>
{
    public const string RouteTemplate = $"{ServerRoutes.Controllers.Release}";
    public override string GetRoute() => RouteTemplate;

    public ReleaseCreateRequest(
        Uri mainIssue,
        DateTime completeDate,
        string platformName,
        string version,
        string description)
        : base(null, null, new(mainIssue, completeDate, platformName, version, description))
    {
    }

    public record Body(
        Uri MainIssue,
        DateTime CompleteDate,
        string PlatformName,
        string Version,
        string Description);
}
