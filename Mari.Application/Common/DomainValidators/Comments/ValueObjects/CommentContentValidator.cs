using FluentValidation;
using Mari.Domain.Comments.ValueObjects;

namespace Mari.Application.Common.DomainValidators.Comments.ValueObjects;

public class CommentContentValidator : AbstractValidator<CommentContent>
{
    public CommentContentValidator()
    {
        RuleFor(cc => cc.Value)
            .NotEmpty();
    }
}
