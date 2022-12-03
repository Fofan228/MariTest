// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using MapsterMapper;
using Mari.Client.Common.Interfaces.Managers;
using Mari.Contracts.Platforms.GetRequests;
using Mari.Contracts.Platforms.Responces;
using Mari.Http.Services;

namespace Mari.Client.Common.Services.Managers;

public class PlatformManager : IPlatformManager
{
    private readonly HttpSender _httpSender;
    private readonly IMapper _mapper;

    public PlatformManager(HttpSender httpSender, IMapper mapper)
    {
        _httpSender = httpSender;
        _mapper = mapper;
    }
    
    // TODO Тестовые данные
    private static List<PlatformResponce> Comments = new List<PlatformResponce>()
    {
        new PlatformResponce("Android",1,1,1),
        new PlatformResponce("Ios",1,1,1)
    };
    
    public async Task<IList<PlatformResponce>> GetAll(CancellationToken token = default)
    {
        var request = new PlatformGetAllRequest();
        var response = await _httpSender.GetAsync(request, token);
        if (!response.IsSuccess) throw new NotImplementedException();
        return null;
    }
}
