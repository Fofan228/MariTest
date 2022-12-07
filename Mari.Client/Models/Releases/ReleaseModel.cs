namespace Mari.Client.Models.Releases;

public class ReleaseModel
{
    public ReleaseModel(Guid id, int? major, int? minor, int? patch, string platformName, string status,
        DateTime? completeDate, DateTime? updateDate, string mainIssue, string description)
    {
        Id = id;
        Version = new VersionModel { Major = major, Minor = minor, Patch = patch };
        PlatformName = platformName;
        Status = status;
        CompleteDate = completeDate;
        UpdateDate = updateDate;
        MainIssue = mainIssue;
        Description = description;
    }

    public Guid Id { get; set; }
    public VersionModel Version { get; set; }
    public string PlatformName { get; set; }
    public string Status { get; set; }
    public DateTime? CompleteDate { get; set; }
    public DateTime? UpdateDate { get; set; }
    public string MainIssue { get; set; }
    public string Description { get; set; }

}
