namespace Mari.Contracts.Releases.Responce;

public class ReleaseResponse 
{
    public ReleaseResponse(string releaseId, string version, string platformName, string status, 
        string mainIssue, DateTime? completeDate, DateTime? updateDate, string description)
    {
        ReleaseId = releaseId;
        Version = version;
        PlatformName = platformName;
        Status = status;
        MainIssue = mainIssue;
        CompleteDate = completeDate;
        UpdateDate = updateDate;
        Description = description;
    }

    public string ReleaseId { get; set; } = null!;
    public string Version { get; set; } = null!;
    public string PlatformName { get; set; } = null!;
    public string Status { get; set; } = null!;
    public string MainIssue { get; set; } = null!;
    public DateTime? CompleteDate { get; set; }= null!;
    public DateTime? UpdateDate { get; set; }= null!;
    public string Description { get; set; } = null;
}
