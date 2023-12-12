using UserManagement.Common;
using UserManagement.Domain.ValueObjects;

namespace UserManagement.Domain;

public class User : Entity
{
    public Email Email { get; }
    public Username Username { get; }
    public FirstName FirstName { get; }
    public LastName LastName { get; }
    public DateTime CreatedAt { get; }
    public DateTime UpdatedAt { get; }

    public User(Email email, Username username, FirstName firstName, LastName lastName)
    {
        Email = email;
        Username = username;
        FirstName = firstName;
        LastName = lastName;
        CreatedAt = new DateTime();
        UpdatedAt = new DateTime();
    }

    public User(Auid id, Email email, Username username, FirstName firstName, LastName lastName, DateTime createdAt, DateTime updatedAt) : base(id)
    {
        Email = email;
        Username = username;
        FirstName = firstName;
        LastName = lastName;
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
    }
}