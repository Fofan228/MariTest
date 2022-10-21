using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using FluentValidation;
using Mari.Domain.ValueObjects;

namespace Mari.Application.Common.DomainValidators.ValueObjects
{
    public class IssueTitleValidator : AbstractValidator<IssueTitle>
    {
        public static readonly Regex IssueTitleRegex = new(IssueTitle.Pattern, RegexOptions.Compiled);
        public IssueTitleValidator()
        {
            RuleFor(it => it.Value)
                .NotEmpty()
                .Matches(IssueTitleRegex)
                .OverridePropertyName(nameof(IssueTitle));
        }
    }
}