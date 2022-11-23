using Mari.Contracts.Common.Routes.Server;
using Mari.Http.Common.Classes;
using Mari.Http.Models;
using Mari.Http.Requests;
using static Mari.Contracts.Comments.PostRequests.CommentCreateRequest;

namespace Mari.Contracts.Comments.PostRequests;

public class CommentCreateRequest : PostRequest<EmptyRoute, EmptyQuery, Body, VoidResponse>
{
    public const string ConstRouteTemplate = $"{ServerRoutes.Controllers.Comment}";
    public override string RouteTemplate => ConstRouteTemplate;

    public CommentCreateRequest(Body body) : base(new(), new(), body)
    {
    }
    
    public record Body(
        Guid releaseId,
        int userId,
        string userName,
        string message
        ):RequestBody;
}
