using System.Security.Claims;
using Mari.Server.Controllers.Common;
using Microsoft.AspNetCore.Mvc;
using Mari.Contracts.Common;
using Microsoft.AspNetCore.Authorization;
using Mari.Server.Authentication.Configurations;
using MediatR;
using Mari.Application.Authentication.Queries.Login;

namespace Mari.Server.Controllers;

[Route(Routes.Server.AuthorizationController)]
public class AuthenticationController : ApiController
{
    private readonly ISender _sender;

    public AuthenticationController(ISender sender)
    {
        _sender = sender;
    }

    [HttpGet]
    [Authorize(AuthenticationSchemes = $"{CookieConfig.AuthenticationScheme}, {OAuthConfig.AuthenticationScheme}")]
    public async Task<RedirectResult> GetToken()
    {
        var redirectUrl = "http://localhost:5001/token";
        var userId = int.Parse(
            User.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value);
        var query = new LoginQuery(userId);
        var authResult = await _sender.Send(query);
        return Redirect($"{redirectUrl}?token={authResult.Token}");
    }

    [AllowAnonymous]
    [HttpGet("/token")]
    public string Get(string token)
    {
        return token;
    }
}
