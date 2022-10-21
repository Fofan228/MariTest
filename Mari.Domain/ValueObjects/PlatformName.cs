using Mari.Domain.Common.BaseClasses;

namespace Mari.Domain.ValueObjects;

public record PlatformName(string Value) : ValueObjectBase
{
    //TODO Для валидации использовать сначала конфигурацию, если нет, то использовать внутренние регулярки
    //TODO Также доделать эту регулярку
    public const string Pattern = @"^[^\d\W]+.*";
    public static implicit operator string(PlatformName value) => value.ToString();
    public override string ToString() => Value;
}