using Humanizer;
using Mari.Client.Common.Interfaces.Formatters;

namespace Mari.Client.Common.Services.Formatters;

public class DateFormatter : IDateFormatter
{
    private const string ConstantFormatDate  = "dd.MM.yyyy";
    private const string ConstantFormatDateTime = "dd.MM.yyyy hh:mm:ss";
    
    public string FormatDate(DateTime? dateTime)
    {
        return dateTime?.ToString(ConstantFormatDate) ?? string.Empty;
    }

    public string FormatDateTime(DateTime? dateTime)
    {
        return dateTime?.ToString(ConstantFormatDateTime) ?? string.Empty;
    }
    public string Humanize(DateTime? dateTime)
    {
        return dateTime?.Humanize(true) ?? string.Empty;
    }
}
