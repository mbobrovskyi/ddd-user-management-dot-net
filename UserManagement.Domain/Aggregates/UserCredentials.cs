using Common.Domain;
using UserManagement.Domain.ValueObjects;

namespace UserManagement.Domain.Aggregates;

public class UserCredentials : AggregateRoot
{
    public Email Email { get; }
    public Username Username { get; }
    public Password Password { get; }
    
    public UserCredentials(long id, Email email, Username username, Password password) : base(id)
    {
        Email = email;
        Username = username;
        Password = password;
    }
}