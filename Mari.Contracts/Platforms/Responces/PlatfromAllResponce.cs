namespace Mari.Contracts.Platforms.Responces;

public class PlatfromAllResponce
{
    public PlatfromAllResponce(IEnumerable<PlatformResponce> platforms)
    {
        Platforms = platforms.ToArray();
    }
    
    public PlatformResponce[] Platforms { get; set; }
}
