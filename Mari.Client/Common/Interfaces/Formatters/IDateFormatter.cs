namespace Mari.Client.Common.Interfaces.Formatters;

public interface IDateFormatter
{
    string FormatDate(DateTime? dateTime);
    
    string FormatDateTime(DateTime? dateTime);
    string Humanize(DateTime? dateTime);
}
