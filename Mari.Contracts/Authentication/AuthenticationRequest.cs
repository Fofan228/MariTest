using Mari.Contracts.Common.Routes.Server;
using Mari.Http.Common.Classes;
using Mari.Http.Models;
using Mari.Http.Requests;
using static Mari.Contracts.Authentication.AuthenticationRequest;

namespace Mari.Contracts.Authentication;
public class AuthenticationRequest : GetRequest<EmptyRoute, Query, VoidResponse>
{
    public const string ConstRouteTemplate = ServerRoutes.Controllers.Authentication;
    public override string RouteTemplate => ConstRouteTemplate;

    public AuthenticationRequest(Query query) : base(new(), query)
    {
    }

    public record Query(string RedirectUri) : RequestQuery;
}
