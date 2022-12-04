using Mari.Contracts.Common.Routes.Server;
using Mari.Http.Common.Classes;
using Mari.Http.Models;
using Mari.Http.Requests;

namespace Mari.Contracts.Comments.DeleteRequests;

public class CommentDeleteRequest : DeleteRequest<CommentDeleteRequest.Route, EmptyQuery, EmptyBody>
{
    public const string ConstRouteTemplate = $"{ServerRoutes.Controllers.Comment}/delete/{{{nameof(Route.id)}}}";
    public override string RouteTemplate => $"{ServerRoutes.Controllers.Comment}/delete/{RouteParams!.id}";

    public CommentDeleteRequest(Route route) : base(route, new())
    {
    }

    public record Route(
            Guid id)
        : RequestRoute;
}
