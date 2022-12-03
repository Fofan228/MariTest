using Mari.Contracts.Common.Routes.Server;
using Mari.Http.Common.Classes;
using Mari.Http.Models;
using Mari.Http.Requests;

namespace Mari.Contracts.Comments.PutRequests;

public class CommentUpdateRequest : PutRequest<EmptyRoute, EmptyQuery, CommentUpdateRequest.Body>
{
    public const string ConstRouteTemplate = $"{ServerRoutes.Controllers.Comment}/update";
    public override string RouteTemplate => ConstRouteTemplate;

    public CommentUpdateRequest(Body body) : base(new(), new(), body)
    {
    }
    
    public record Body(
        Guid commentId,
        string message
    ):RequestBody;
}
