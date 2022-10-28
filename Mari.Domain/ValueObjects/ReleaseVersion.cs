using Mari.Domain.Common.Models;

namespace Mari.Domain.ValueObjects;

public record ReleaseVersion : ValueObject, IComparable<ReleaseVersion>
{
    #region Constants
    public const uint MaxMajor = uint.MaxValue - 1;
    public const uint MaxMinor = uint.MaxValue - 1;
    public const uint MaxPatch = uint.MaxValue - 1;
    public const uint MinMajor = 0;
    public const uint MinMinor = 0;
    public const uint MinPatch = 0;
    #endregion

    public static readonly ReleaseVersion MinValue = ReleaseVersion.Create(MinMajor, MinMinor, MinPatch + 1);
    public static readonly ReleaseVersion MaxValue = ReleaseVersion.Create(MaxMajor, MaxMinor, MaxPatch);

    public static ReleaseVersion Create(uint major, uint minor, uint patch)
    {
        return new ReleaseVersion(major, minor, patch);
    }

    private ReleaseVersion(uint major, uint minor, uint patch)
    {
        Major = major;
        Minor = minor;
        Patch = patch;
    }

    public uint Major { get; private set; }
    public uint Minor { get; private set; }
    public uint Patch { get; private set; }

    public int CompareTo(ReleaseVersion? other)
    {
        if (other is null)
            throw new NullReferenceException(
                message: $"{nameof(ReleaseVersion)}: {nameof(other)} is null");

        var firstPartCompareResult = Major.CompareTo(other.Minor);
        if (firstPartCompareResult != 0) return firstPartCompareResult;

        var secondPartCompareResult = Minor.CompareTo(other.Minor);
        if (secondPartCompareResult != 0) return secondPartCompareResult;

        return Patch.CompareTo(other.Patch);
    }

    public string ToVersionString() => $"{Major}.{Minor}.{Patch}";

    #region Operators
    public static bool operator >(ReleaseVersion left, ReleaseVersion right) => left.CompareTo(right) > 0;
    public static bool operator <(ReleaseVersion left, ReleaseVersion right) => left.CompareTo(right) < 0;
    public static bool operator <=(ReleaseVersion left, ReleaseVersion right) => left.CompareTo(right) <= 0;
    public static bool operator >=(ReleaseVersion left, ReleaseVersion right) => left.CompareTo(right) >= 0;
    #endregion
}
