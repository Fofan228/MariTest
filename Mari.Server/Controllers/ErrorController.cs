using Mari.Server.Controllers.Common;
using Microsoft.AspNetCore.Mvc;
using Mari.Contracts.Common;

namespace Mari.Server.Controllers;

[Route(Routes.Server.Error)]
public class ErrorController : ApiController
{
    public IActionResult Error()
    {
        return Problem();
    }
}