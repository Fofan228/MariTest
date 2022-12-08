using Mari.Contracts.Comments.Responces;
using Mari.Contracts.Common.Routes.Server;
using Mari.Http.Common.Classes;
using Mari.Http.Requests;

namespace Mari.Contracts.Comments.GetRequests;

public class GetUserCommentsRequest : GetRequest<IEnumerable<CommentResponse>>
{

    public const string ConstRouteTemplate = $"{ServerRoutes.Controllers.Comment}/user/{{{nameof(Route.ReleaseId)}}}";
    public override string RouteTemplate => ConstRouteTemplate;
    
    public GetUserCommentsRequest(Route route) : base(route: route)
    {
    }

    public record Route(Guid ReleaseId) : RequestRoute;
}
