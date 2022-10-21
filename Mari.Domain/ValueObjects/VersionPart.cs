using Mari.Domain.Common.BaseClasses;

namespace Mari.Domain.ValueObjects;

public record VersionPart(int Value) : ValueObjectBase, IComparable<VersionPart>
{
    public int CompareTo(VersionPart? other)
    {
        if (other is null)
            throw new NullReferenceException(
                message: $"{nameof(VersionPart)}: {nameof(other)} is null");

        return Value.CompareTo(other.Value);
    }

    public static VersionPart Parse(string versionPart)
    {
        if (!int.TryParse(versionPart, out var value))
        {
            throw new ArgumentException(
                paramName: nameof(versionPart),
                message: $"Invalid {nameof(versionPart)} format. Expected format: 1");
        }

        return new VersionPart(value);
    }

    public static VersionPart Parse(int versionPart)
    {
        return new VersionPart(versionPart);
    }

    #region Operators
    public static bool operator >(VersionPart left, VersionPart right) => left.CompareTo(right) > 0;
    public static bool operator <(VersionPart left, VersionPart right) => left.CompareTo(right) < 0;
    public static bool operator <=(VersionPart left, VersionPart right) => left.CompareTo(right) <= 0;
    public static bool operator >=(VersionPart left, VersionPart right) => left.CompareTo(right) >= 0;
    public static VersionPart operator +(VersionPart left, VersionPart right) => left with { Value = left.Value + right.Value };
    public static VersionPart operator -(VersionPart left, VersionPart right) => left with { Value = left.Value - right.Value };
    public static VersionPart operator ++(VersionPart left) => left with { Value = left.Value + 1 };
    public static VersionPart operator --(VersionPart left) => left with { Value = left.Value - 1 };
    public static VersionPart operator *(VersionPart left, VersionPart right) => left with { Value = left.Value * right.Value };
    public static VersionPart operator /(VersionPart left, VersionPart right) => left with { Value = left.Value / right.Value };
    public static VersionPart operator %(VersionPart left, VersionPart right) => left with { Value = left.Value % right.Value };
    public static implicit operator int(VersionPart versionPart) => versionPart.Value;
    #endregion

    public const int MinValue = 0;
}