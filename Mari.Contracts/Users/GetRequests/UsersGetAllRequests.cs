using Mari.Contracts.Common.Routes.Server;
using Mari.Contracts.Users.Responce;
using Mari.Http.Models;
using Mari.Http.Requests;

namespace Mari.Contracts.Users.GetRequests;

public class UsersGetAllRequests: GetRequest<EmptyRoute, EmptyQuery, UserAllResponce>
{

    public const string ConstRouteTemplate = $"{ServerRoutes.Controllers.User}";
    public override string RouteTemplate => ConstRouteTemplate;
    
    public UsersGetAllRequests()
        : base(null, null)
    {
    }
}
