// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

namespace Mari.Contracts.Users.Responce;

public class UserAllResponce
{
    public UserAllResponce(IEnumerable<UserResponce> users)
    {
        Users = users.ToArray();
    }
    
    public UserResponce[] Users { get; set; }
}
