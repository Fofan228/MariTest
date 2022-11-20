using MapsterMapper;
using Mari.Contracts.Common.Routes.Server;
using Mari.Contracts.Releases;
using Mari.Server.Controllers.Common;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Mari.Server.Controllers;

[Route(ServerRoutes.Controllers.Release)]
public class ReleaseController : ApiController
{
    private readonly ISender _sender;
    private readonly IMapper _mapper;

    public ReleaseController(ISender sender, IMapper mapper)
    {
        _sender = sender;
        _mapper = mapper;
    }

    [HttpPost(ReleaseCreateRequest.RouteTemplate)]
    public ActionResult Create([FromBody] ReleaseCreateRequest.Body body)
    {
        return Ok();
    }
}
