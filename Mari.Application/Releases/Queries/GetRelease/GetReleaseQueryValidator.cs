using System.Data;
using FluentValidation;
using Mari.Application.Common.Shared.Paging;
using Mari.Domain.Releases.ValueObjects;

namespace Mari.Application.Releases.Queries.GetRelease;

internal class GetReleaseQueryValidator : AbstractValidator<GetReleaseQuery>
{
    public GetReleaseQueryValidator(IValidator<ReleaseId> releaseIdValidator)
    {
        RuleFor(query => query.Id)
            .SetValidator(releaseIdValidator);
    }
}
