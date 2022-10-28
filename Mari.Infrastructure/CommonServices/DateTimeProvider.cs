using Mari.Application.Common.Interfaces.CommonServices;

namespace Mari.Infrastructure.CommonServices;

public class DateTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow => DateTime.UtcNow;
}
