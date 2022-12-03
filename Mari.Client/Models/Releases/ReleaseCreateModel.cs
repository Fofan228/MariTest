using System.ComponentModel.DataAnnotations;

namespace Mari.Client.Models.Releases;

public class ReleaseCreateModel
{

    public string? MainIssue { get; set; } = null!;
    public string? PlatformName { get; set; } = null!;
    public DateTime? CompleteDate { get; set; }
    public uint? Major { get; set; } 
    public uint? Minor { get;  set; }
    public uint? Patch { get;  set; }
    public string? Description { get; set; } = null!;
}
