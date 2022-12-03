namespace Mari.Contracts.Platforms.Responces;

public class PlatformResponce
{
    public PlatformResponce(string platformName, int major, int minor, int patch)
    {
        PlatformName = platformName;
        Major = major;
        Minor = minor;
        Patch = patch;
    }

    public string PlatformName { get;  set; }
    public int Major { get;  set; }
    public int Minor { get;  set; }
    public int Patch { get;  set; }

}
