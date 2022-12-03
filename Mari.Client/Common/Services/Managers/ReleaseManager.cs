using System.Xml.Linq;
using MapsterMapper;
using Mari.Client.Common.Interfaces.Managers;
using Mari.Client.Models.Releases;
using Mari.Contracts.Releases;
using Mari.Contracts.Releases.GetRequests;
using Mari.Contracts.Releases.PostRequests;
using Mari.Contracts.Releases.Responce;
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

    public async Task Create(ReleaseCreateModel model, CancellationToken token)
    {
        var body = _mapper.Map<ReleaseCreateRequest.Body>(model);
        var request = new ReleaseCreateRequest(body);
        var response = await _httpSender.PostAsync(request, token);
        if (!response.IsSuccess) throw new NotImplementedException();
    }

    public async Task<ReleaseResponse> Get(Guid id,CancellationToken token)
    {
        var request = new ReleaseGetRequest(new(id));
        var response = await _httpSender.GetAsync(request, token);
        if (!response.IsSuccess) throw new NotImplementedException();
        return null;
    }

    public async Task<IEnumerable<ReleaseResponse>> GetCurrentReleases(CancellationToken token)
    {
        var request = new ReleaseGetCurrentRequest();
        var response = await _httpSender.GetAsync(request, token);
        if (!response.IsSuccess) throw new NotImplementedException();
        return null;
    }

    public async Task<IEnumerable<ReleaseResponse>> GetPlannedReleases(CancellationToken token)
    {
        var request = new ReleaseGetPlannedRequest();
        var response = await _httpSender.GetAsync(request, token);
        if (!response.IsSuccess) throw new NotImplementedException();
        return null;
    }

    public async Task<IEnumerable<ReleaseResponse>> GetInWorkReleases(CancellationToken token)
    {
        var request = new ReleaseGetInWorkRequest();
        var response = await _httpSender.GetAsync(request, token);
        if (!response.IsSuccess) throw new NotImplementedException();
        return null;
    }

    public async Task UpdateRelease(ReleaseResponse model,CancellationToken token)
    {
        var body = _mapper.Map<ReleaseUpdateRequest.Body>(model);
        var request = new ReleaseUpdateRequest(body);
        var response = await _httpSender.PostAsync(request, token);
        if (!response.IsSuccess) throw new NotImplementedException();
    }

    public async Task DeleteRelease(Guid id,CancellationToken token)
    {
        var request = new ReleaseDeleteRequest(new(id));
        var response = await _httpSender.PostAsync(request, token);
        if (!response.IsSuccess) throw new NotImplementedException(); 
    }
    public async Task<IEnumerable<ReleaseResponse>> Test()
    {
        List<ReleaseResponse> Releases = new List<ReleaseResponse>()
        {
            new ReleaseResponse(Guid.NewGuid(), 1,1,1, "Android", "Testing", "http",
                new DateTime(2022, 11, 11), new DateTime(2022, 11, 11), "GG"),
            new ReleaseResponse(Guid.NewGuid(), 1,1,1, "Android", "Testing", "http",
                new DateTime(2022, 11, 11), new DateTime(2022, 11, 11), "GG"),
            new ReleaseResponse(Guid.NewGuid(), 1,1,1, "Android", "Testing", "http",
                new DateTime(2022, 11, 11), new DateTime(2022, 11, 11), "GG"),
            new ReleaseResponse(Guid.NewGuid(), 1,1,1, "Android", "Testing", "http",
                new DateTime(2022, 11, 11), new DateTime(2022, 11, 11), "GG"),
            new ReleaseResponse(Guid.NewGuid(), 1,1,1, "Android", "Testing", "http",
                new DateTime(2022, 11, 11), new DateTime(2022, 11, 11), "GG"),
            new ReleaseResponse(Guid.NewGuid(), 1,1,1, "Android", "Testing", "http",
                new DateTime(2022, 11, 11), new DateTime(2022, 11, 11), "GG"),
            new ReleaseResponse(Guid.NewGuid(), 1,1,1, "Android", "Testing", "http",
                new DateTime(2022, 11, 11), new DateTime(2022, 11, 11), "GG"),
        };

        return Releases;
    }
}
