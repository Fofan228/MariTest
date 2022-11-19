using System.Net.Http.Json;
using System.Text.Json.Serialization;
using Mari.Http.Services;

namespace Mari.Http.Common;

public abstract class Request<TRoute, TQuery, TBody, TResponse> : IRequest<TResponse>
    where TResponse : notnull
{
    protected Request(TRoute? route, TQuery? query, TBody? body)
    {
        RouteParams = route;
        QueryParams = query;
        BodyContent = body;
    }

    public abstract string GetRoute();

    [JsonIgnore] public TRoute? RouteParams { get; set; } = default!;
    [JsonIgnore] public TQuery? QueryParams { get; set; } = default!;
    [JsonIgnore] public TBody? BodyContent { get; set; } = default!;

    public string GetQueryString()
    {
        var properties = typeof(TQuery).GetProperties();
        var queryParameters = new Dictionary<string, string>();
        foreach (var property in properties)
        {
            var value = property.GetValue(QueryParams);
            string stringValue = value?.ToString() ?? string.Empty;
            if (string.IsNullOrWhiteSpace(stringValue)) continue;
            queryParameters.Add(property.Name, stringValue);
        }
        return QueryBuilder.BuildQuery(queryParameters);
    }

    public JsonContent GetBody() => JsonContent.Create(BodyContent);
}
