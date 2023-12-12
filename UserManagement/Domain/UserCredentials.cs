using UserManagement.Common;
using UserManagement.Domain.ValueObjects;

namespace UserManagement.Domain;

public class UserCredentials : Entity
{
    public Password Password { get; }

    public UserCredentials(Auid id, Password password) : base(id)
    {
        Password = password;
    }
}