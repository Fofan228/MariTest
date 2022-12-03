using Mari.Contracts.Common.Routes.Server;
using Mari.Http.Common.Classes;
using Mari.Http.Models;
using Mari.Http.Requests;

namespace Mari.Contracts.Users.PutRequests;

public class UserUpdateRequest: PutRequest<EmptyRoute, EmptyQuery, UserUpdateRequest.Body>
{
    public const string ConstRouteTemplate = $"{ServerRoutes.Controllers.User}";
    public override string RouteTemplate => ConstRouteTemplate;

    public UserUpdateRequest(Body body) : base(new(), new(), body)
    {
    }
    
    public record Body(
        int id,
        string name
        ,string role, 
        IEnumerable<string> notifications,
        bool isActive
    ):RequestBody;
}
