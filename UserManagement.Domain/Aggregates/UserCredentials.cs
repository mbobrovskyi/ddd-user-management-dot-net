using Common.Domain;
using UserManagement.Domain.ValueObjects;

namespace UserManagement.Domain.Aggregates;

public class UserCredentials : AggregateRoot
{
    public Email Email { get; }
    public HashPassword HashPassword { get; }

    public UserCredentials(long id, Email email, HashPassword hashPassword) : base(id)
    {
        Email = email;
        HashPassword = hashPassword;
    }
}