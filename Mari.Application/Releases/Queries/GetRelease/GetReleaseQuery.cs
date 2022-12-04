using ErrorOr;
using Mari.Application.Releases.Results;
using Mari.Domain.Releases.ValueObjects;
using MediatR;

namespace Mari.Application.Releases.Queries.GetRelease;

public record GetReleaseQuery : IRequest<ErrorOr<ReleaseResult>>
{
    public GetReleaseQuery(Guid id)
    {
        Id = ReleaseId.Create(id);
    }

    public ReleaseId Id { get; set; }
}
