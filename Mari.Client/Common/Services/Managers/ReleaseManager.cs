using Mari.Client.Common.Interfaces.Managers;
using Mari.Contracts.Releases;
using Mari.Http.Services;

namespace Mari.Client.Common.Services.Managers;

public class ReleaseManager : IReleaseManager
{
    private readonly HttpSender _httpSender;

    public ReleaseManager(HttpSender httpSender)
    {
        _httpSender = httpSender;
    }

    public async Task Create(ReleaseCreateRequest request, CancellationToken token)
    {
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
