namespace Mari.Contracts.Releases.Responses;

public record ReleaseResponse(
    Guid Id,
    string Version,
    string PlatformName,
    string Status,
    DateTime CompleteDate,
    DateTime UpdateDate,
    string MainIssue,
    string Description);
