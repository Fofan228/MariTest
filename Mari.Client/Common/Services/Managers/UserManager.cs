﻿using MapsterMapper;
using Mari.Client.Common.Interfaces.Managers;
using Mari.Contracts.Users.GetRequests;
using Mari.Contracts.Users.PutRequests;
using Mari.Contracts.Users.Responce;
using Mari.Http.Services;

namespace Mari.Client.Common.Services.Managers;

public class UserManager : IUserManager
{
    private readonly HttpSender _httpSender;
    private readonly IMapper _mapper;

    public UserManager(HttpSender httpSender, IMapper mapper)
    {
        _httpSender = httpSender;
        _mapper = mapper;
    }
    
    // TODO Тестовые данные
    private  List<UserResponce> Users = new List<UserResponce>()
    {
        new UserResponce(0,"Putin","ReleaseManager",new List<string>(){
            "Android","IOS"},true),
        
        new UserResponce(0,"Ахимат","ReleaseManager",new List<string>(){
            "Android"} ,true)
    };
    
    public async Task<IList<UserResponce>> GetAll(CancellationToken token = default)
    {
        var request = new UsersGetAllRequest();
        var response = await _httpSender.GetAsync(request, token);
        if (!response.IsSuccess) throw new NotImplementedException();
        return null;
    }

    public async Task Update(UserResponce model, CancellationToken token = default)
    {
        var body = _mapper.Map<UserUpdateRequest.Body>(model);
        var request = new UserUpdateRequest(body);
        var response = await _httpSender.PutAsync(request, token);
        if (!response.IsSuccess) throw new NotImplementedException();
    }
}
