using System.Security.Claims;
namespace Mari.Client.Models.Users;

public class User
{

    public User(ClaimsPrincipal principal)
    {
        Principal = principal;

    }

    public ClaimsPrincipal Principal { get; }
    public string Name { get; }
}
