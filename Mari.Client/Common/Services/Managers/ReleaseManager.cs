using MapsterMapper;
using Mari.Client.Common.Interfaces.Managers;
using Mari.Client.Models.Releases;
using Mari.Contracts.Releases;
using Mari.Http.Services;

namespace Mari.Client.Common.Services.Managers;

public class ReleaseManager : IReleaseManager
{
    private readonly HttpSender _httpSender;
    private readonly IMapper _mapper;

    public ReleaseManager(HttpSender httpSender, IMapper mapper)
    {
        _httpSender = httpSender;
        _mapper = mapper;
    }

    public async Task Create(NewReleaseFormModel model, CancellationToken token)
    {
        var body = _mapper.Map<ReleaseCreateRequest.Body>(model);
        var request = new ReleaseCreateRequest(body);
        var response = await _httpSender.PostAsync(request, token);
        if (!response.IsSuccess) throw new NotImplementedException();
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
