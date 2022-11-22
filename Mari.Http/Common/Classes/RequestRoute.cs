using System.Text;
using Mari.Http.Common.Interfaces;

namespace Mari.Http.Common.Classes;

public abstract record RequestRoute : IRequestRoute
{
    public virtual string GetRoute(string RouteTemplate)
    {
        var route = new StringBuilder(RouteTemplate);
        var properties = GetType().GetProperties();
        foreach (var property in properties)
        {
            var value = property.GetValue(this)?.ToString();
            if (value is not null)
            {
                route = route.Replace($"{{{property.Name}}}", value);
            }
        }
        return route.ToString();
    }
}
