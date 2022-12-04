namespace Mari.Contracts.Releases.Responses;

public record ReleaseResponse(
    Guid Id,
    int Major,
    int Minor,
    int Patch,
    string PlatformName,
    string Status,
    DateTime CompleteDate,
    DateTime UpdateDate,
    string MainIssue,
    string Description);
