using UserManagement.Common;
using UserManagement.Domain.ValueObjects;

namespace UserManagement.Domain.Entities;

public class UserCredentials : Entity
{
    public Password Password { get; }

    public UserCredentials(Password password)
    {
        Password = password;
    }
}