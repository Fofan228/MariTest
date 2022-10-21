using Mari.Domain.Common.BaseClasses;

namespace Mari.Domain.ValueObjects;

public record ReleaseVersion(
    VersionPart FirstPart,
    VersionPart SecondPart,
    VersionPart ThirdPart) : ValueObjectBase, IComparable<ReleaseVersion>
{
    public static readonly ReleaseVersion MinValue = ReleaseVersion.Parse("0.0.1");
    
    public static ReleaseVersion Parse(string version)
    {
        var parts = version.Split('.');

        if (parts.Length != 3)
        {
            throw new ArgumentException(
                paramName: nameof(version),
                message: $"Invalid {nameof(version)} format. Expected format: 1.2.3");
        }

        return new ReleaseVersion(
            VersionPart.Parse(parts[0]),
            VersionPart.Parse(parts[1]),
            VersionPart.Parse(parts[2]));
    }

    public override string ToString()
    {
        return $"{FirstPart}.{SecondPart}.{ThirdPart}";
    }

    public int CompareTo(ReleaseVersion? other)
    {
        if (other is null)
            throw new NullReferenceException(
                message: $"{nameof(ReleaseVersion)}: {nameof(other)} is null");

        var firstPartCompareResult = FirstPart.CompareTo(other.FirstPart);
        if (firstPartCompareResult != 0) return firstPartCompareResult;

        var secondPartCompareResult = SecondPart.CompareTo(other.SecondPart);
        if (secondPartCompareResult != 0) return secondPartCompareResult;

        return ThirdPart.CompareTo(other.ThirdPart);
    }

    #region Operators
    public static bool operator >(ReleaseVersion left, ReleaseVersion right)
    {
        if (left.FirstPart > right.FirstPart)
            return true;
        if (left.FirstPart < right.FirstPart)
            return false;

        if (left.SecondPart > right.SecondPart)
            return true;
        if (left.SecondPart < right.SecondPart)
            return false;

        if (left.ThirdPart > right.ThirdPart)
            return true;
        if (left.ThirdPart < right.ThirdPart)
            return false;

        return false;
    }

    public static bool operator <(ReleaseVersion left, ReleaseVersion right)
    {
        return !(left > right);
    }

    public static bool operator <=(ReleaseVersion left, ReleaseVersion right)
    {
        return left == right || left < right;
    }

    public static bool operator >=(ReleaseVersion left, ReleaseVersion right)
    {
        return left == right || left > right;
    }
    #endregion
}