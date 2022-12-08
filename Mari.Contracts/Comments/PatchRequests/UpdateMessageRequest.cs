using Mari.Contracts.Common.Routes.Server;
using Mari.Http.Common.Classes;
using Mari.Http.Models;
using Mari.Http.Requests;

namespace Mari.Contracts.Comments.PatchRequests;

public class UpdateMessageRequest : PatchRequest<VoidResponse>
{
    public const string ConstRouteTemplate = $"{ServerRoutes.Controllers.Comment}/update_comment";
    public override string RouteTemplate => ConstRouteTemplate;

    public UpdateMessageRequest(Body body) : base(body: body)
    {
    }
    
    public record Body(
        Guid CommentId,
        string Message,
        DateTime CreateDate,
        bool IsEdit
    ):RequestBody;
}
