using System.Security.Claims;
using Mari.Server.Controllers.Common;
using Microsoft.AspNetCore.Mvc;
using Mari.Contracts.Common;
using Microsoft.AspNetCore.Authorization;
using Mari.Server.Authentication.Configurations;
using MediatR;
using Mari.Application.Authentication.Queries.Login;
using Mari.Contracts.Authentication;
using System.IdentityModel.Tokens.Jwt;

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
    public async Task<RedirectResult> GetToken(/*AuthenticationRequest request*/)
    {
        var request = new AuthenticationRequest("http://localhost:5001/token");
        var userId = int.Parse(
            User.Claims.First(c => c.Type == ClaimTypes.NameIdentifier).Value);
        var query = new LoginQuery(userId);
        var authResult = await _sender.Send(query);
        return Redirect($"{request.redirectUrl}?token={authResult.Token}");
    }

    //TODO Тестовый метод
    [AllowAnonymous]
    [HttpGet("/token")]
    public IEnumerable<Claim> Get(string token)
    {
        var jwtToken = new JwtSecurityToken(token);
        return jwtToken.Claims;
    }
}
