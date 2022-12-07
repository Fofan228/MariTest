using MapsterMapper;
using Mari.Client.Common.Interfaces.Managers;
using Mari.Http.Services;

namespace Mari.Client.Common.Services.Managers;

public class CommentManager : ICommentManager
{
    private readonly HttpSender _httpSender;
    private readonly IMapper _mapper;

    public CommentManager(HttpSender httpSender, IMapper mapper)
    {
        _httpSender = httpSender;
        _mapper = mapper;
    }

    public async Task Create(object comment, CancellationToken token = default)
    {
    }

    public async Task<IList<object>> GetAllUserComment(Guid releaseId, CancellationToken token = default)
    {
        return null;
    }

    public async Task<IList<object>> GetAllSystemComment(Guid releaseId, CancellationToken token = default)
    {
        return null;
    }

    public async Task UpdateComments(object comment, CancellationToken token = default)
    {
    }

    public async Task DeleteComments(Guid commnetId, CancellationToken token = default)
    {
    }
}

