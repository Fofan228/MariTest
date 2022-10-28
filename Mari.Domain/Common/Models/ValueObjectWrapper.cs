namespace Mari.Domain.Common.Models;

public abstract record ValueObjectWrapper<T>(T Value) :
    ValueObject,
    IComparable<ValueObjectWrapper<T>>,
    IEquatable<T>,
    IComparable<T>
    where T : IComparable<T>
{
    public sealed override string ToString()
    {
        return Value.ToString() ?? string.Empty;
    }

    public int CompareTo(ValueObjectWrapper<T>? other)
    {
        return Value.CompareTo(other == null ? default : other.Value);
    }

    public bool Equals(T? other)
    {
        return Value.Equals(other);
    }

    public int CompareTo(T? other)
    {
        return Value.CompareTo(other);
    }

    public static implicit operator T(ValueObjectWrapper<T> value) => value.Value;

    #region Operators
    public static bool operator <(ValueObjectWrapper<T> left, ValueObjectWrapper<T> right) => left.CompareTo(right) < 0;
    public static bool operator >(ValueObjectWrapper<T> left, ValueObjectWrapper<T> right) => left.CompareTo(right) > 0;
    public static bool operator <=(ValueObjectWrapper<T> left, ValueObjectWrapper<T> right) => left.CompareTo(right) <= 0;
    public static bool operator >=(ValueObjectWrapper<T> left, ValueObjectWrapper<T> right) => left.CompareTo(right) >= 0;
    public static bool operator <(ValueObjectWrapper<T> left, T right) => left.CompareTo(right) < 0;
    public static bool operator >(ValueObjectWrapper<T> left, T right) => left.CompareTo(right) > 0;
    public static bool operator <=(ValueObjectWrapper<T> left, T right) => left.CompareTo(right) <= 0;
    public static bool operator >=(ValueObjectWrapper<T> left, T right) => left.CompareTo(right) >= 0;
    public static bool operator <(T left, ValueObjectWrapper<T> right) => left.CompareTo(right) < 0;
    public static bool operator >(T left, ValueObjectWrapper<T> right) => left.CompareTo(right) > 0;
    public static bool operator <=(T left, ValueObjectWrapper<T> right) => left.CompareTo(right) <= 0;
    public static bool operator >=(T left, ValueObjectWrapper<T> right) => left.CompareTo(right) >= 0;
    public static bool operator ==(ValueObjectWrapper<T> left, T right) => left.CompareTo(right) == 0;
    public static bool operator !=(ValueObjectWrapper<T> left, T right) => left.CompareTo(right) != 0;
    public static bool operator ==(T left, ValueObjectWrapper<T> right) => left.CompareTo(right) == 0;
    public static bool operator !=(T left, ValueObjectWrapper<T> right) => left.CompareTo(right) != 0;
    #endregion
}
