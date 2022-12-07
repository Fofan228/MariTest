namespace Mari.Client.Models.Releases;

public class PlatformModel
{
    public string Name { get; set; } = null!;
    public VersionModel LastVersion { get; set; }
}
