using Mari.Server.Controllers.Common;
using Microsoft.AspNetCore.Mvc;
using Mari.Contracts.Common;
using MediatR;
using Mari.Application.Queries;

namespace Mari.Server.Controllers;

[Route(Routes.Server.TestController)]
public class TestController : ApiController
{
    private readonly ISender _sender;

    public TestController(ISender sender)
    {
        _sender = sender;
    }

    public async Task<IActionResult> TestMethod()
    {
        var result = await _sender.Send(new TestQuery("test"));

        if (result.IsError)
            return Problem(result.Errors);

        return Ok(result.Value);
    }
}