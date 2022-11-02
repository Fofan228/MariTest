using ErrorOr;
using FluentValidation.Results;

namespace Mari.Application.Common.Extensions;

public static class ValidationResultExtensions
{
    public static List<Error> ToDomainErrors(this ValidationResult validationResult)
    {
        return validationResult.Errors
            .Select(x => Error.Validation(x.PropertyName, x.ErrorMessage))
            .ToList();
    }
}
