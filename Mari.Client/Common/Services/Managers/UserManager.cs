using MapsterMapper;
using Mari.Client.Common.Interfaces.Managers;
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

    public async Task<IList<object>> GetAll(CancellationToken token = default)
    {
        return null;
    }

    public async Task Update(object model, CancellationToken token = default)
    {
    }
}
