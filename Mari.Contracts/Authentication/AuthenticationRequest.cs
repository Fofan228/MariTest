using Mari.Contracts.Common.Routes.Server;
using Mari.Http.Models;
using Mari.Http.Requests;
using static Mari.Contracts.Authentication.AuthenticationRequest;

namespace Mari.Contracts.Authentication;
public class AuthenticationRequest : GetRequest<object, Query, VoidResponse>
{
    public const string Route = ServerRoutes.Controllers.Authentication;
    public override string GetRoute() => Route;

    public AuthenticationRequest(string redirectUrl) : base(null, new(new(redirectUrl)))
    {
    }

    public record Query(Uri RedirectUri);
}
