// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using MapsterMapper;
using Mari.Client.Common.Interfaces.Managers;
using Mari.Contracts.Users.GetRequests;
using Mari.Contracts.Users.PostRequests;
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
    
    public async Task<IEnumerable<UserResponce>> GetAll(CancellationToken token)
    {
        var request = new UsersGetAllRequests();
        var response = await _httpSender.GetAsync(request, token);
        if (!response.IsSuccess) throw new NotImplementedException();
        return null;
    }

    public async Task Update(UserResponce model, CancellationToken token)
    {
        var body = _mapper.Map<UserUpdateRequest.Body>(model);
        var request = new UserUpdateRequest(body);
        var response = await _httpSender.PostAsync(request, token);
        if (!response.IsSuccess) throw new NotImplementedException();

    }
}
