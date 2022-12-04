using System.Xml.Linq;
using Mapster;
using MapsterMapper;
using Mari.Client.Common.Interfaces.Managers;
using Mari.Client.Models.Releases;
using Mari.Contracts.Releases;
using Mari.Contracts.Releases.DeleteRequests;
using Mari.Contracts.Releases.GetRequests;
using Mari.Contracts.Releases.PostRequests;
using Mari.Contracts.Releases.PutRequests;
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
    

    public async Task Create(ReleaseCreateModel model, CancellationToken token = default)
    {
        var body = _mapper.Map<CreateReleaseRequest.Body>(model);
        var request = new CreateReleaseRequest(body);
        var response = await _httpSender.PostAsync(request, token);
        if (!response.IsSuccess) throw new NotImplementedException();
    }

    public async Task<ReleaseModel> Get(Guid iReleaseResponsed,CancellationToken token = default)
    {
        /*var request = new GetR(new(id));
        var response = await _httpSender.GetAsync(request, token);
        if (!response.IsSuccess) throw new NotImplementedException();*/
        return null;
    }

    public async Task<IList<ReleaseModel>> GetCurrentReleases(CancellationToken token = default)
    {
        var request = new GetCurrentReleasesRequest();
        var response = await _httpSender.GetAsync(request, token);
        if (!response.IsSuccess) throw new NotImplementedException();
        return _mapper.Map<IList<ReleaseModel>>(response.Response!);
    }

    public async Task<IList<ReleaseModel>> GetPlannedReleases(CancellationToken token = default)
    {
        var request = new GetPlannedReleasesRequest();
        var response = await _httpSender.GetAsync(request, token);
        if (!response.IsSuccess) throw new NotImplementedException();
        return _mapper.Map<IList<ReleaseModel>>(response.Response!);
    }

    public async Task<IList<ReleaseModel>> GetInWorkReleases(CancellationToken token = default)
    {
        var request = new GetInWorkReleasesRequest();
        var response = await _httpSender.GetAsync(request, token);
        if (!response.IsSuccess) throw new NotImplementedException();
        return _mapper.Map<IList<ReleaseModel>>(response.Response!);
    }

    public async Task<IList<ReleaseModel>> GetArchive(CancellationToken token = default)
    {
        var request = new GetArchiveReleaseRequest();
        var response = await _httpSender.GetAsync(request, token);
        
        if (!response.IsSuccess) throw new NotImplementedException();
        return  _mapper.Map<IList<ReleaseModel>>(response.Response!);
    }

    public async Task UpdateRelease(ReleaseModel model,CancellationToken token = default)
    {
        var body = _mapper.Map<ReleaseUpdateRequest.Body>(model);
        /*var request = new ReleaseUpdateRequest(body);
        var response = await _httpSender.PutAsync(request, token);
        if (!response.IsSuccess) throw new NotImplementedException();*/
    }

    public async Task DeleteRelease(Guid id,CancellationToken token = default)
    {
        var request = new ReleaseDeleteRequest(new(id));
        var response = await _httpSender.DeleteAsync(request, token);
        if (!response.IsSuccess) throw new NotImplementedException(); 
    }

    public async Task<IList<PlatformResponse>> GetAllPlatforms(CancellationToken token = default)
    {
        var request = new GetAllPlatformsRequest();
        var response = await _httpSender.GetAsync(request, token);
        if (!response.IsSuccess) throw new NotImplementedException();
        return null;
    }


}
