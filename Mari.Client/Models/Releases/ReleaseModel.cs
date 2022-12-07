namespace Mari.Client.Models.Releases;

public class ReleaseModel
{
    public Guid Id { get; set; }
    public VersionModel Version { get; set; } = new();
    public string PlatformName { get; set; } = string.Empty;
    public string Status { get; set; } = string.Empty;
    public DateTime? CompleteDate { get; set; } = DateTime.Now.AddDays(10);
    public DateTime? UpdateDate { get; set; } = null;
    public string MainIssue { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;

}
