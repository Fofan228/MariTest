namespace Mari.Contracts.Platforms.Responces;

public class PlatformResponce
{
    public PlatformResponce(string platformName, uint major, uint minor, uint patch)
    {
        PlatformName = platformName;
        Major = major;
        Minor = minor;
        Patch = patch;
    }

    public string PlatformName { get;  set; }
    public uint Major { get;  set; }
    public uint Minor { get;  set; }
    public uint Patch { get;  set; }

}
