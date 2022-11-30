using Mari.Contracts.Common.Routes.Server;
using Mari.Contracts.Platforms.Responces;
using Mari.Contracts.Releases.Responce;
using Mari.Http.Common.Classes;
using Mari.Http.Models;
using Mari.Http.Requests;
using static Mari.Contracts.Platforms.GetRequests.PlatformGetAllRequest;

namespace Mari.Contracts.Platforms.GetRequests;

public class PlatformGetAllRequest : GetRequest<EmptyRoute, EmptyQuery, IEnumerable<PlatformResponce>>
{

    public const string ConstRouteTemplate = $"{ServerRoutes.Controllers.Platform}";
    public override string RouteTemplate => ConstRouteTemplate;
    
    public PlatformGetAllRequest()
        : base(null, null)
    {
    }
}

