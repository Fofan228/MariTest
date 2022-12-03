using Mari.Contracts.Comments.Responce;
using Mari.Contracts.Common.Routes.Server;
using Mari.Http.Common.Classes;
using Mari.Http.Models;
using Mari.Http.Requests;
using static Mari.Contracts.Comments.GetRequests.CommentSystemGetAllRequest;

namespace Mari.Contracts.Comments.GetRequests;

public class CommentSystemGetAllRequest : GetRequest<Route, EmptyQuery, IEnumerable<CommentResponse>>
{

    public const string ConstRouteTemplate = $"{ServerRoutes.Controllers.Comment}/system/{{{nameof(Route.id)}}}";
    public override string RouteTemplate => $"{ServerRoutes.Controllers.Comment}/system/{RouteParams!.id}";

    public CommentSystemGetAllRequest(
        Route route)
        : base(route, new())
    {
    }


    public record Route(Guid id) : RequestRoute;
}
