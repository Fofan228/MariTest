using System.Net.Http.Json;
using Mari.Http.Common.Classes;

namespace Mari.Http.Models;

public sealed record EmptyBody : RequestBody
{
    public override JsonContent? GetBody() => null;
}
