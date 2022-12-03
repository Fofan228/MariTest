﻿namespace Mari.Contracts.Releases.Responce;

public class ReleaseResponse 
{
    public ReleaseResponse(Guid? releaseId, uint? major, uint? minor, uint? patch, string? platformName, string? status,
        string? mainIssue, DateTime? completeDate, DateTime? updateDate, string? description)
    {
        ReleaseId = releaseId;
        Major = major;
        Minor = minor;
        Patch = patch;
        PlatformName = platformName;
        Status = status;
        MainIssue = mainIssue;
        CompleteDate = completeDate;
        UpdateDate = updateDate;
        Description = description;
    }

    public Guid? ReleaseId { get; set; }
    public uint? Major { get;  set; }
    public uint? Minor { get;  set; }
    public uint? Patch { get;  set; }
    public string? PlatformName { get; set; } = null!;
    public string? Status { get; set; } = null!;
    public string? MainIssue { get; set; } = null!;
    public DateTime? CompleteDate { get; set; }= null!;
    public DateTime? UpdateDate { get; set; }= null!;
    public string? Description { get; set; } = null;
}
