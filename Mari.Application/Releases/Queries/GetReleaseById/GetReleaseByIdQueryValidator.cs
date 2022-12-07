using System.Data;
using FluentValidation;
using Mari.Application.Common.Shared.Paging;
using Mari.Domain.Releases.ValueObjects;

namespace Mari.Application.Releases.Queries.GetRelease;

internal class GetReleaseByIdQueryValidator : AbstractValidator<GetReleaseByIdQuery>
{
    public GetReleaseByIdQueryValidator(IValidator<ReleaseId> releaseIdValidator)
    {
        RuleFor(query => query.ReleaseId)
            .SetValidator(releaseIdValidator);
    }
}
