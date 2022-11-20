using FluentValidation;
using Mari.Domain.Comments.ValueObjects;

namespace Mari.Application.Common.DomainValidators.Comments.ValueObjects;

public class CommentIdValidator : AbstractValidator<CommentId>
{
    public CommentIdValidator()
    {
        RuleFor(ci => ci.Value)
            .NotEmpty();
    }
}
