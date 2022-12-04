using MapsterMapper;
using Mari.Client.Common.Interfaces.Managers;
using Mari.Client.Models.Releases;
using Mari.Contracts.Releases.GetRequests;
using Mari.Contracts.Releases.PostRequests;
using Mari.Contracts.Releases.Responses;
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

    // TODO Тестовые данные
    private static List<ReleaseResponse> Comments = new List<ReleaseResponse>()
    {
        // new ReleaseResponse(Guid.NewGuid(), 1,1,1, "Android", "Testing", "http",
        //     new DateTime(2022, 11, 11), new DateTime(2022, 11, 11), "GG"),
        // new ReleaseResponse(Guid.NewGuid(), 1,1,1, "Android", "Testing", "http",
        //     new DateTime(2022, 11, 11), new DateTime(2022, 11, 11), "GG"),
        // new ReleaseResponse(Guid.NewGuid(), 1,1,1, "Android", "Testing", "http",
        //     new DateTime(2022, 11, 11), new DateTime(2022, 11, 11), "GG"),
        // new ReleaseResponse(Guid.NewGuid(), 1,1,1, "Android", "Testing", "http",
        //     new DateTime(2022, 11, 11), new DateTime(2022, 11, 11), "GG"),
        // new ReleaseResponse(Guid.NewGuid(), 1,1,1, "Android", "Testing", "http",
        //     new DateTime(2022, 11, 11), new DateTime(2022, 11, 11), "GG"),
        // new ReleaseResponse(Guid.NewGuid(), 1,1,1, "Android", "Testing", "http",
        //     new DateTime(2022, 11, 11), new DateTime(2022, 11, 11), "GG"),
        // new ReleaseResponse(Guid.NewGuid(), 1,1,1, "Android", "Testing", "http",
        //     new DateTime(2022, 11, 11), new DateTime(2022, 11, 11), "GG"),
    };

    public async Task Create(ReleaseCreateModel model, CancellationToken token = default)
    {
        var body = _mapper.Map<CreateReleaseRequest.Body>(model);
        var request = new CreateReleaseRequest(body);
        var response = await _httpSender.PostAsync(request, token);
        if (!response.IsSuccess) throw new NotImplementedException();
    }

    public async Task<ReleaseResponse> Get(Guid id, CancellationToken token = default)
    {
        return null;
    }

    public async Task<IList<ReleaseResponse>> GetCurrentReleases(CancellationToken token = default)
    {
        var request = new GetCurrentReleasesRequest();
        var response = await _httpSender.GetAsync(request, token);
        if (!response.IsSuccess) throw new NotImplementedException();
        return null;
    }

    public async Task<IList<ReleaseResponse>> GetPlannedReleases(CancellationToken token = default)
    {
        var request = new GetPlannedReleasesRequest();
        var response = await _httpSender.GetAsync(request, token);
        if (!response.IsSuccess) throw new NotImplementedException();
        return null;
    }

    public async Task<IList<ReleaseResponse>> GetInWorkReleases(CancellationToken token = default)
    {
        var request = new GetInWorkReleasesRequest();
        var response = await _httpSender.GetAsync(request, token);
        if (!response.IsSuccess) throw new NotImplementedException();
        return null;
    }

    public async Task UpdateRelease(ReleaseResponse model, CancellationToken token = default)
    {
    }

    public async Task DeleteRelease(Guid id, CancellationToken token = default)
    {
    }

}
