using System.Diagnostics.CodeAnalysis;
using Mari.Domain.Common.Models;

namespace Mari.Domain.Releases.ValueObjects;

public record PlatformName : ValueObjectWrapper<string>
{
    //TODO Для валидации использовать сначала конфигурацию, если нет, то использовать внутренние регулярки
    public const string Pattern = @"^[^\d\W]+.*";

    public static PlatformName Create(string value)
    {
        return new PlatformName(value);
    }

    private PlatformName(string Value) : base(Value)
    {
    }
}

