using MapsterMapper;
using Mari.Application.Releases.Commands.CreateDraftRelease;
using Mari.Application.Releases.Commands.CreateRelease;
using Mari.Application.Releases.Commands.CreateReleaseFromDraft;
using Mari.Application.Releases.Queries.GetAllPlatforms;
using Mari.Application.Releases.Queries.GetCurrentReleases;
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

    [HttpPost(ReleaseCreateRequest.ConstRouteTemplate)]
    public async Task<ActionResult<object>> CreateDraftRelease(
        [FromBody] object body,
        CancellationToken token)
    {
        var request = _mapper.Map<CreateDraftReleaseCommand>(body);
        var result = await _sender.Send(request, token);

        if (result.IsError) return Problem(result.Errors);
        var response = _mapper.Map<object>(result.Value);

        return Ok(response);
    }

    public async Task<ActionResult<object>> CreateRelease(
        [FromBody] object body,
        CancellationToken token)
    {
        var request = _mapper.Map<CreateReleaseCommand>(body);
        var result = await _sender.Send(request, token);

        if (result.IsError) return Problem(result.Errors);
        var response = _mapper.Map<object>(result.Value);

        return Ok(response);
    }

    public async Task<ActionResult<object>> CreateReleaseFromDraft(
        [FromBody] object body,
        CancellationToken token)
    {
        var request = _mapper.Map<CreateReleaseFromDraftCommand>(body);
        var result = await _sender.Send(request, token);

        if (result.IsError) return Problem(result.Errors);
        var response = _mapper.Map<object>(result.Value);

        return Ok(response);
    }

    public async Task<ActionResult<IEnumerable<string>>> GetAllPlatforms(
        CancellationToken token)
    {
        var request = new GetAllPlatformsQuery();
        var result = await _sender.Send(request, token);

        if (result.IsError) return Problem(result.Errors);
        var response = result.Value;

        return Ok(response);
    }

    public async Task<ActionResult<object>> GetCurrentReleases(
        CancellationToken token)
    {
        var request = _mapper.Map<GetCurrentReleasesQuery>(Request.Query);
        var result = await _sender.Send(request, token);

        if (result.IsError) return Problem(result.Errors);
        var response = _mapper.Map<object>(result.Value);

        return Ok(response);
    }

    public async Task<ActionResult<object>> GetInWorkReleases(
        CancellationToken token)
    {
        var request = _mapper.Map<GetCurrentReleasesQuery>(Request.Query);
        var result = await _sender.Send(request, token);

        if (result.IsError) return Problem(result.Errors);
        var response = _mapper.Map<object>(result.Value);

        return Ok(response);
    }

    public async Task<ActionResult> GetPlanningReleases(
        CancellationToken token)
    {
        var request = _mapper.Map<GetCurrentReleasesQuery>(Request.Query);
        var result = await _sender.Send(request, token);

        if (result.IsError) return Problem(result.Errors);
        var response = _mapper.Map<object>(result.Value);

        return Ok(response);
    }
}
