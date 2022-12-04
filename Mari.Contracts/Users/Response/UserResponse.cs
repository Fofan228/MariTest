namespace Mari.Contracts.Users.Response;

public class UserResponse
{
    public UserResponse(int id, string name,string role, IEnumerable<string> notifications,bool isActive) 
    {
        Id = id;
        Username = name;
        Role = role;
        Notifications = notifications.ToList();
        IsActive = isActive;
    }
    public int Id { get; set; }
    public string Username { get; set; } 
    public string Role { get; set; }
    public List<string> Notifications{ get; set;}
    public bool IsActive { get; set; }
}
