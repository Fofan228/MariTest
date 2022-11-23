using Mari.Contracts.Common.Routes.Server;
using Mari.Http.Common.Classes;
using Mari.Http.Models;
using Mari.Http.Requests;
using static Mari.Contracts.Comments.PostRequests.CommentUpdateRequest;

namespace Mari.Contracts.Comments.PostRequests;

public class CommentUpdateRequest : PostRequest<EmptyRoute, EmptyQuery, Body, VoidResponse>
{
    public const string ConstRouteTemplate = $"{ServerRoutes.Controllers.Comment}/update";
    public override string RouteTemplate => ConstRouteTemplate;

    public CommentUpdateRequest(Body body) : base(new(), new(), body)
    {
    }
    
    public record Body(
        Guid commentId,
        string userName,
        string message
    ):RequestBody;
}
