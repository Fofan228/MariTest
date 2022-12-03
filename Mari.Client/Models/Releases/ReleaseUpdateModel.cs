﻿namespace Mari.Client.Models.Releases;

public class ReleaseUpdateModel
{
    public ReleaseUpdateModel(Guid? releaseId, uint? major, uint? minor, uint? patch, string? platformName,
        string? status, string? mainIssue, DateTime? completeDate, string? description)
    {
        ReleaseId = releaseId;
        Major = major;
        Minor = minor;
        Patch = patch;
        PlatformName = platformName;
        Status = status;
        MainIssue = mainIssue;
        CompleteDate = completeDate;
        Description = description;
    }

    public Guid? ReleaseId { get; set; } = null!;
    public uint? Major { get;  set; }
    public uint? Minor { get;  set; }
    public uint? Patch { get;  set; }
    public string? PlatformName { get; set; } = null!;
    public string? Status { get; set; } = null!;
    public string? MainIssue { get; set; } = null!;
    public DateTime? CompleteDate { get; set; }= null!;
    public string? Description { get; set; } = null!;
}
