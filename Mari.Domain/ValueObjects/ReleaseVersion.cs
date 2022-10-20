using Mari.Domain.Common.BaseClasses;

namespace Mari.Domain.ValueObjects;

public record ReleaseVersion(int FirstPart, int SecondPart, int ThirdPart) : ValueObjectBase
{
    public static ReleaseVersion ConvertFromString(string version)
    {
        var parts = version.Split('.');

        if (parts.Length != 3)
        {
            throw new ArgumentException(
                paramName: nameof(version),
                message: $"Invalid {nameof(version)} format. Expected format: 1.2.3");
        }

        return new ReleaseVersion(int.Parse(parts[0]), int.Parse(parts[1]), int.Parse(parts[2]));
    }
}