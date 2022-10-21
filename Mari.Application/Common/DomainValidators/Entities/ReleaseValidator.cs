using FluentValidation;
using Mari.Domain.Entities;
using Mari.Domain.ValueObjects;

namespace Mari.Application.Common.DomainValidators.Entities;

public class ReleaseValidator : AbstractValidator<Release>
{
    public ReleaseValidator(IValidator<ReleaseVersion> releaseVersionValidator)
    {
        //TODO Доделать после добавления репозиториев и провайдера даты
    }
}