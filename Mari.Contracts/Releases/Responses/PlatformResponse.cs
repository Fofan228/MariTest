namespace Mari.Contracts.Releases.Responses;

public record PlatformResponse(
    string Name,
    int? Major,
    int? Minor,
    int? Patch);
