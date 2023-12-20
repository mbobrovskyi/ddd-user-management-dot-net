using Common.Domain;
using UserManagement.Domain.ValueObjects;

namespace UserManagement.Domain.Aggregates;

public sealed class User : AggregateRoot
{
    public Email Email { get; }
    public FirstName FirstName { get; }
    public LastName LastName { get; }
    public DateTime CreatedAt { get; }
    public DateTime UpdatedAt { get; }

    public User(Email email, FirstName firstName, LastName lastName)
    {
        Email = email;
        FirstName = firstName;
        LastName = lastName;
        CreatedAt = DateTime.Now;
        UpdatedAt = DateTime.Now;
    }
    
    public User(long id, Email email, FirstName firstName, LastName lastName, DateTime createdAt, DateTime updatedAt) 
        : base(id)
    {
        Email = email;
        FirstName = firstName;
        LastName = lastName;
        CreatedAt = createdAt;
        UpdatedAt = updatedAt;
    }
}