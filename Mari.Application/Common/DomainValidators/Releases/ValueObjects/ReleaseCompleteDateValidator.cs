using FluentValidation;
using Mari.Domain.Releases.ValueObjects;

namespace Mari.Application.Common.DomainValidators.Releases.ValueObjects;

public class ReleaseCompleteDateValidator : AbstractValidator<ReleaseCompleteDate>
{
    public ReleaseCompleteDateValidator()
    {
        RuleFor(rcd => rcd.Value)
            .NotEmpty();
    }
}
