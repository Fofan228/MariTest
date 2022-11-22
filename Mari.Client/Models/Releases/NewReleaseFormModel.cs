namespace Mari.Client.Models.Releases;

public class NewReleaseFormModel
{
    public string MainIssue { get; set; } = null!;
    public string PlatformName { get; set; } = null!;
    public DateTime CompleteDate { get; set; }
    public string Version { get; set; } = null!;
    public string Description { get; set; } = null!;
}