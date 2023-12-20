using UserManagement.Domain.Aggregates;
using UserManagement.Domain.Repositories;
using UserManagement.Domain.ValueObjects;

namespace UserManagement.Infrastructure.Repositories;

public class UserCredentialsRepository : IUserCredentialsRepository
{
    public UserCredentials GetByEmail(Email email)
    {
        return UserCredentials.Single(u => u.Email.Value == email.Value);
    }

    public UserCredentials Save(UserCredentials userCredentials)
    {
        UserCredentials.RemoveAll(x => x.Id == userCredentials.Id);
        UserCredentials.Add(userCredentials);
        return userCredentials;
    }
    
    private static readonly UserCredentials AliceCredentials = new(
        1,
        Email.Create("alice@mail.com").Value,
        HashPassword.Create("Password").Value
    );
    
    private static readonly UserCredentials BobCredentials = new(
        2,
        Email.Create("alice@mail.com").Value,
        HashPassword.Create("Password").Value
    );
    
    private static readonly List<UserCredentials> UserCredentials = new()
    {
        AliceCredentials, BobCredentials
    };
}