using System.Web;
using System.Net;
namespace Mari.Contracts.Common.Requests;

public abstract class GetRequest
{
    public abstract IEnumerable<KeyValuePair<string, string>> EnumerateParams();
    public string ToUrlEncodedQuery()
    {
        var query = HttpUtility.ParseQueryString(string.Empty);
        foreach (var param in EnumerateParams())
        {
            query[param.Key] = param.Value;
        }
        return query.ToString() ?? string.Empty;
    }
}
