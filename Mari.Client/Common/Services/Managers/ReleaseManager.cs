using MapsterMapper;
using Mari.Client.Common.Http.ProblemsHandling;
using Mari.Client.Common.Interfaces.Managers;
using Mari.Client.Models.Releases;
using Mari.Contracts.Releases;
using Mari.Http.Services;

namespace Mari.Client.Common.Services.Managers;

public class ReleaseManager : IReleaseManager
{
    private readonly HttpSender _httpSender;
    private readonly IMapper _mapper;
    private readonly ProblemHandler _problemHandler;

    public ReleaseManager(HttpSender httpSender, IMapper mapper, ProblemHandler problemHandler)
    {
        _httpSender = httpSender;
        _mapper = mapper;
        _problemHandler = problemHandler;
    }

    public async Task Create(NewReleaseFormModel model, CancellationToken token)
    {
        var body = _mapper.Map<ReleaseCreateRequest.Body>(model);
        var request = new ReleaseCreateRequest(body);
        var response = await _httpSender.PostAsync(request, token);
        if (!response.IsSuccess) _problemHandler.HandleProblem(response.Problem!);
    }

    public void DeleteRelease(string releaseId)
    {
        throw new NotImplementedException();
    }

    public void Get(Guid id)
    {
        throw new NotImplementedException();
    }

    public void GetCurrentReleases()
    {
        throw new NotImplementedException();
    }

    public void GetInWorkReleases()
    {
        throw new NotImplementedException();
    }

    public void GetPlannedReleases()
    {
        throw new NotImplementedException();
    }

    public void UpdateRelease()
    {
        throw new NotImplementedException();
    }
}
