using Mari.Server.Controllers.Common;
using Microsoft.AspNetCore.Mvc;
using Mari.Contracts.Common;
using Microsoft.AspNetCore.Authorization;

namespace Mari.Server.Controllers;

[AllowAnonymous]
[Route(Routes.Server.ErrorController)]
public class ErrorController : ApiController
{
    public IActionResult Error()
    {
        return Problem();
    }
}
