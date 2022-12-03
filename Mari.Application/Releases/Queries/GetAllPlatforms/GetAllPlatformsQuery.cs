using ErrorOr;
using MediatR;

namespace Mari.Application.Releases.Queries.GetAllPlatforms;

public record GetAllPlatformsQuery : IRequest<ErrorOr<IEnumerable<string>>>;
