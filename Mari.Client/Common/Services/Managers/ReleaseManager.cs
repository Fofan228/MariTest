using System.Xml.Linq;
using Mapster;
using MapsterMapper;
using Mari.Client.Common.Interfaces.Managers;
using Mari.Client.Models.Enums;
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
    
    private List<ReleaseModel> CurrentList = new List<ReleaseModel>();
    private List<ReleaseModel> PlannedList = new List<ReleaseModel>();
    private List<ReleaseModel> InWorkList = new List<ReleaseModel>();
    private List<PlatformResponse> Platforms = new List<PlatformResponse>()
    {
        new PlatformResponse("Android",1,1,1),
        new PlatformResponse("IOS",1,1,1)
    };
    public ReleaseManager(HttpSender httpSender, IMapper mapper)
    {
        _httpSender = httpSender;
        _mapper = mapper;
    }

    public async Task Create(ReleaseCreateModel model, CancellationToken token = default)
    {
        PlannedList.Add(new ReleaseModel(Guid.NewGuid(),model.Major,
            model.Minor,model.Patch,model.PlatformName,"Planing",
            model.CompleteDate,DateTime.Now, model.MainIssue, model.Description));

        
        Platforms.Add(new PlatformResponse( model.PlatformName, model.Major, model.Minor,model.Patch));
        /*bool a = false;
        foreach (var VARIABLE in Platforms)
        {
            if(VARIABLE.Name == model.PlatformName) a = true;

        }
        if(a)
            Platforms.Add(new PlatformResponse( model.PlatformName, model.Major, model.Minor,model.Patch));*/
         
        /*var body = _mapper.Map<CreateReleaseRequest.Body>(model);
        var request = new CreateReleaseRequest(body);
        var response = await _httpSender.PostAsync(request, token);
        if (!response.IsSuccess) throw new NotImplementedException();*/
    }

    public async Task<ReleaseModel> Get(Guid id,CancellationToken token = default)
    {
        foreach (var VARIABLE in CurrentList)
        {
            if (VARIABLE.Id == id)
                return VARIABLE;
        }
        foreach (var VARIABLE in PlannedList)
        {
            if (VARIABLE.Id == id)
                return VARIABLE;
        }
        foreach (var VARIABLE in InWorkList)
        {
            if (VARIABLE.Id == id)
                return VARIABLE;
        }
        
        /*var request = new GetR(new(id));
        var response = await _httpSender.GetAsync(request, token);
        if (!response.IsSuccess) throw new NotImplementedException();*/
        return null;
    }

    public async Task<IList<ReleaseModel>> GetCurrentReleases(CancellationToken token = default)
    {
        
        
        /*var request = new GetCurrentReleasesRequest();
        var response = await _httpSender.GetAsync(request, token);
        if (!response.IsSuccess) throw new NotImplementedException();
        return _mapper.Map<IList<ReleaseModel>>(response.Response!); */
        return CurrentList;
    }

    public async Task<IList<ReleaseModel>> GetPlannedReleases(CancellationToken token = default)
    {
        /*var request = new GetPlannedReleasesRequest();
        var response = await _httpSender.GetAsync(request, token);
        if (!response.IsSuccess) throw new NotImplementedException();
        return _mapper.Map<IList<ReleaseModel>>(response.Response!);*/
        return PlannedList;
    }

    public async Task<IList<ReleaseModel>> GetInWorkReleases(CancellationToken token = default)
    {
        /*var request = new GetInWorkReleasesRequest();
        var response = await _httpSender.GetAsync(request, token);
        if (!response.IsSuccess) throw new NotImplementedException();
        return _mapper.Map<IList<ReleaseModel>>(response.Response!);*/
        return InWorkList;
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
        for (int i = 0; i < CurrentList.Count; i++)
        {
            if (CurrentList[i].Id == model.Id)
                CurrentList[i] = model;
        }
        for (int i = 0; i < PlannedList.Count; i++)
        {
            if (PlannedList[i].Id == model.Id)
                PlannedList[i] = model;
        }
        for (int i = 0; i < InWorkList.Count; i++)
        {
            if (InWorkList[i].Id == model.Id)
                InWorkList[i] = model;
        }
       
        
        
        /*
        var body = _mapper.Map<ReleaseUpdateRequest.Body>(model);
        var request = new ReleaseUpdateRequest(body);
        var response = await _httpSender.PutAsync(request, token);
        if (!response.IsSuccess) throw new NotImplementedException();*/
        
    }

    public async Task DeleteRelease(Guid id,CancellationToken token = default)
    {
        
        for (int i = 0; i < CurrentList.Count; i++)
        {
            if (CurrentList[i].Id == id)
                CurrentList.RemoveAt(i);
        }
        for (int i = 0; i < PlannedList.Count; i++)
        {
            if (PlannedList[i].Id == id)
                PlannedList.RemoveAt(i);
        }
        for (int i = 0; i < InWorkList.Count; i++)
        {
            if (InWorkList[i].Id == id)
                InWorkList.RemoveAt(i);
        }
        
        /*var request = new ReleaseDeleteRequest(new(id));
        var response = await _httpSender.DeleteAsync(request, token);
        if (!response.IsSuccess) throw new NotImplementedException(); */
    }

    public async Task<IList<PlatformResponse>> GetAllPlatforms(CancellationToken token = default)
    {
        /*var request = new GetAllPlatformsRequest();
        var response = await _httpSender.GetAsync(request, token);
        if (!response.IsSuccess) throw new NotImplementedException();
        return response.Response.ToList();*/
        return Platforms;
    }

    public IList<ReleaseModel> TransInWork(ReleaseModel model)
    {

        for (int i = 0; i < PlannedList.Count; i++)
        {
            if (PlannedList[i].Equals(model))
            {
                model.Status = nameof(ReleaseStatus.Developing);
                PlannedList.RemoveAt(i);
                InWorkList.Add(model);
            }
        }
        return PlannedList;
    }

    public  IList<ReleaseModel> TransInCurrent(ReleaseModel model)
    {
        for (int i = 0; i < InWorkList.Count; i++)
        {
            if (InWorkList[i].Equals(model))
            {
                model.Status = "Complete";
                InWorkList.RemoveAt(i);
                CurrentList.Add(model);
            }
        }

        return InWorkList;
    }

}
