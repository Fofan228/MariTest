using ErrorOr;
using Mari.Application.Common.Shared.Paging;
using Mari.Application.Releases.Results;
using MediatR;

namespace Mari.Application.Releases.Queries.GetInWorkReleases;

public record GetInWorkReleasesQuery(int? page = null, int pageSize = 0) :
    PageRequest(page, pageSize),
    IRequest<ErrorOr<IEnumerable<ReleaseResult>>>;
