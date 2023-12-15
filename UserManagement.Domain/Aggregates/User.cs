using Common.Domain;
using UserManagement.Domain.ValueObjects;

namespace UserManagement.Domain.Aggregates;

public sealed class User : AggregateRoot
{
    public Email Email { get; }
    public Username Username { get; }
    public FirstName FirstName { get; }
    public LastName LastName { get; }
    public DateTime CreatedAt { get; }
    public DateTime UpdatedAt { get; }
    
    public User(Email email, Username username, FirstName firstName, LastName lastName, DateTime? createdAt, 
        DateTime? updatedAt, long? id) : base(id)
    {
        Email = email;
        Username = username;
        FirstName = firstName;
        LastName = lastName;
        CreatedAt = createdAt ?? DateTime.Now;
        UpdatedAt = updatedAt ?? DateTime.Now;
    }
}