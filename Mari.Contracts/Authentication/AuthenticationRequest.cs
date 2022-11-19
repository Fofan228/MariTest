using Mari.Http.Models;
using Mari.Http.Requests;
using static Mari.Contracts.Authentication.AuthenticationRequest;

namespace Mari.Contracts.Authentication;
public class AuthenticationRequest : GetRequest<object, Query, VoidResponse>
{
    public const string Route = Common.Routes.Server.AuthenticationController;

    public AuthenticationRequest(string redirectUrl) : base(null, new(new(redirectUrl)))
    {
    }

    public override string GetRoute() => Route;

    public record Query(Uri RedirectUri);
}
