using System.Diagnostics.CodeAnalysis;
using Mari.Domain.Common.Models;

namespace Mari.Domain.Releases.ValueObjects;

public record PlatformName : ValueObjectWrapper<string, PlatformName>
{
    [Obsolete(PublicConstructorObsoleteMessage, true)]
    public PlatformName() { }

    //TODO Для валидации использовать сначала конфигурацию, если нет, то использовать внутренние регулярки
    public const string Pattern = @"^[^\d\W]+.*";
    public const int MaxLength = 100;
}

