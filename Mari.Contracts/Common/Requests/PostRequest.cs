using System.Net.Http.Json;

namespace Mari.Contracts.Common.Requests;

public abstract class PostRequest
{
    public JsonContent ToJsonContent()
    {
        return JsonContent.Create(this);
    }
}
