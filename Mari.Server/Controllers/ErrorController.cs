using Mari.Server.Controllers.Common;
using Microsoft.AspNetCore.Mvc;
using Mari.Contracts.Common;
using Microsoft.AspNetCore.Authorization;
using Mari.Contracts.Common.Routes.Server;

namespace Mari.Server.Controllers;

[AllowAnonymous]
[Route(ServerRoutes.Controllers.Error)]
public class ErrorController : ApiController
{
    public IActionResult Error()
    {
        return Problem(Domain.Common.Errors.Errors.User.UserNotFound);
    }
}
