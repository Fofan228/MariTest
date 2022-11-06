using System.Web;
using Mari.Contracts.Common.Requests;

namespace Mari.Contracts.Authentication;
public class AuthenticationRequest : GetRequest
{
    public AuthenticationRequest(string token)
    {
        Token = token;
    }

    public string Token { get; }

    public override IEnumerable<KeyValuePair<string, string>> EnumerateParams()
    {
        yield return new(nameof(Token), Token);
    }
}
