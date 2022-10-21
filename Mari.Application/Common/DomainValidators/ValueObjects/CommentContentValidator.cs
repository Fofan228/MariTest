using System.Text.RegularExpressions;
using FluentValidation;
using Mari.Domain.ValueObjects;

namespace Mari.Application.Common.DomainValidators.ValueObjects;

public class CommentContentValidator : AbstractValidator<CommentContent>
{
    public static readonly Regex CommentContentRegex = new(CommentContent.Pattern, RegexOptions.Compiled);
    public CommentContentValidator()
    {
        RuleFor(cc => cc.Value)
            .NotEmpty()
            .MaximumLength(CommentContent.MaxLength)
            .Matches(CommentContentRegex)
            .OverridePropertyName(nameof(CommentContent));
    }
}