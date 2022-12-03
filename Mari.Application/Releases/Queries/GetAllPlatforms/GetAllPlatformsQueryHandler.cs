using ErrorOr;
using Mari.Application.Common.Interfaces.Persistence;
using MediatR;

namespace Mari.Application.Releases.Queries.GetAllPlatforms;

public class GetAllPlatformsQueryHandler : IRequestHandler<GetAllPlatformsQuery, ErrorOr<IEnumerable<string>>>
{
    private readonly IReleaseRepository _releaseRepository;

    public GetAllPlatformsQueryHandler(IReleaseRepository releaseRepository)
    {
        _releaseRepository = releaseRepository;
    }

    public async Task<ErrorOr<IEnumerable<string>>> Handle(GetAllPlatformsQuery request, CancellationToken token)
    {
        return await _releaseRepository.GetAllPlatforms()
            .Select(p => (string)p.Name)
            .ToListAsync(token);
    }
}
