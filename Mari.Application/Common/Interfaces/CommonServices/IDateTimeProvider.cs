namespace Mari.Application.Common.Interfaces.CommonServices;

public interface IDateTimeProvider
{
    DateTime UtcNow { get; }
}
