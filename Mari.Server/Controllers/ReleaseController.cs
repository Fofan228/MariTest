using MapsterMapper;
using Mari.Application.Releases.Commands.CreateDraftRelease;
using Mari.Application.Releases.Commands.CreateRelease;
using Mari.Application.Releases.Commands.CreateReleaseFromDraft;
using Mari.Application.Releases.Queries.GetAllPlatforms;
using Mari.Application.Releases.Queries.GetCurrentReleases;
using Mari.Application.Releases.Queries.GetInWorkReleases;
using Mari.Application.Releases.Queries.GetPlannedReleases;
using Mari.Contracts.Common.Routes.Server;
using Mari.Contracts.Releases.GetRequests;
using Mari.Contracts.Releases.PostRequests;
using Mari.Contracts.Releases.Responses;
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

    [HttpGet(GetAllPlatformsRequest.ConstRouteTemplate)]
    public async Task<ActionResult<IEnumerable<PlatformResponse>>> GetAllPlatforms(CancellationToken token)
    {
        var request = new GetAllPlatformsQuery();
        var result = await _sender.Send(request, token);

        if (result.IsError) return Problem(result.Errors);
        var response = _mapper.Map<IEnumerable<PlatformResponse>>(result.Value);

        return Ok(response);
    }

    [HttpGet(GetCurrentReleasesRequest.ConstRouteTemplate)]
    public async Task<ActionResult<IEnumerable<ReleaseResponse>>> GetCurrentReleases(CancellationToken token)
    {
        var request = new GetCurrentReleasesQuery();
        var result = await _sender.Send(request, token);

        if (result.IsError) return Problem(result.Errors);
        var response = _mapper.Map<IEnumerable<ReleaseResponse>>(result.Value);

        return Ok(response);
    }

    [HttpGet(GetInWorkReleasesRequest.ConstRouteTemplate)]
    public async Task<ActionResult<IEnumerable<ReleaseResponse>>> GetInWorkReleases(CancellationToken token)
    {
        var request = new GetInWorkReleasesQuery();
        var result = await _sender.Send(request, token);

        if (result.IsError) return Problem(result.Errors);
        var response = _mapper.Map<IEnumerable<ReleaseResponse>>(result.Value);

        return Ok(response);
    }

    [HttpGet(GetPlannedReleasesRequest.ConstRouteTemplate)]
    public async Task<ActionResult<IEnumerable<ReleaseResponse>>> GetPlannedReleases(CancellationToken token)
    {
        var request = new GetPlannedReleasesQuery();
        var result = await _sender.Send(request, token);

        if (result.IsError) return Problem(result.Errors);
        var response = _mapper.Map<IEnumerable<ReleaseResponse>>(result.Value);

        return Ok(response);
    }

    [HttpPost(CreateReleaseRequest.ConstRouteTemplate)]
    public async Task<ActionResult> CreateRelease(
        [FromBody] CreateReleaseRequest.Body body,
        CancellationToken token)
    {
        var request = _mapper.Map<CreateReleaseCommand>(body);
        var result = await _sender.Send(request, token);

        if (result.IsError) return Problem(result.Errors);

        return Ok(); //TODO заменить на Created
    }

    [HttpPost(CreateDraftReleaseRequest.ConstRouteTemplate)]
    public async Task<ActionResult> CreateDraftRelease(
        [FromBody] CreateDraftReleaseRequest.Body body,
        CancellationToken token)
    {
        var request = _mapper.Map<CreateDraftReleaseCommand>(body);
        var result = await _sender.Send(request, token);

        if (result.IsError) return Problem(result.Errors);

        return Ok();
    }

    [HttpPost(CreateReleaseFromDraftRequest.ConstRouteTemplate)]
    public async Task<ActionResult> CreateReleaseFromDraft(
        [FromRoute] CreateReleaseFromDraftRequest.Route route,
        CancellationToken token)
    {
        var request = _mapper.Map<CreateReleaseFromDraftCommand>(route);
        var result = await _sender.Send(request, token);

        if (result.IsError) return Problem(result.Errors);

        return Ok();
    }
}
