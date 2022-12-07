namespace Mari.Client.Models.Releases;

public class ReleaseModel
{
    public Guid Id { get; set; }
    public VersionModel Version { get; set; } = new();
    public string PlatformName { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
    public DateTime? CompleteDate { get; set; } = new DateTime();
    public DateTime? UpdateDate { get; set; } = new DateTime();
    public string MainIssue { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;

}
