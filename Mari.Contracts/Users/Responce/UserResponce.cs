// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace Mari.Contracts.Users.Responce;

public class UserResponce
{
    public UserResponce(int id, string name,string role, IEnumerable<string> notifications,bool isActive) 
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
