using System.Web;

namespace Mari.Http.Services;

public static class QueryBuilder
{
    public static string BuildQuery(IEnumerable<KeyValuePair<string, string>> parameters)
    {
        var query = HttpUtility.ParseQueryString(string.Empty);
        foreach (var param in parameters)
            query[param.Key] = param.Value;
        return query.ToString() ?? string.Empty;
    }
}
