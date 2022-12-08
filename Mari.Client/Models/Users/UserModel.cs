namespace Mari.Client.Models.Users;

public class UserModel
{
    public int Id { get; set; }
    public string Username { get; set; } = null!;
    public UserRole Role { get; set; }
    public List<string> Notifications { get; set; } = null!;
    public bool IsActive { get; set; } 
}
