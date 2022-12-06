// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace Mari.Client.Models.Releases;

public class ReleaseModel
{
    public ReleaseModel(Guid id, int? major, int? minor, int? patch, string platformName, string status,
        DateTime? completeDate, DateTime? updateDate, string mainIssue, string description)
    {
        Id = id;
        Major = major;
        Minor = minor;
        Patch = patch;
        PlatformName = platformName;
        Status = status;
        CompleteDate = completeDate;
        UpdateDate = updateDate;
        MainIssue = mainIssue;
        Description = description;
    }

    public Guid Id { get; set; }
    public int? Major { get; set; }
    public int? Minor { get; set; }
    public int? Patch { get; set; }
    public string PlatformName { get; set; }
    public string Status { get; set; }
    public DateTime? CompleteDate { get; set; }
    public DateTime? UpdateDate { get; set; }
    public string MainIssue { get; set; }
    public string Description { get; set; }

}
