using System.ComponentModel.DataAnnotations;

namespace Mari.Client.Models.Releases;

public class ReleaseCreateModel
{

    public string? MainIssue { get; set; } = null!;
    public string? PlatformName { get; set; } = null!;
    public DateTime? CompleteDate { get; set; }
    public int? Major { get; set; } 
    public int? Minor { get;  set; }
    public int? Patch { get;  set; }
    public string? Description { get; set; } = null!;
}
