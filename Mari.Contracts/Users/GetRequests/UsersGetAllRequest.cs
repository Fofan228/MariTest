using Mari.Contracts.Common.Routes.Server;
using Mari.Contracts.Users.Response;
using Mari.Http.Models;
using Mari.Http.Requests;

namespace Mari.Contracts.Users.GetRequests;

public class UsersGetAllRequest: GetRequest<EmptyRoute, EmptyQuery, IEnumerable<UserResponse>>
{

    public const string ConstRouteTemplate = $"{ServerRoutes.Controllers.User}";
    public override string RouteTemplate => ConstRouteTemplate;
    
    public UsersGetAllRequest()
        : base(null, null)
    {
    }
}
