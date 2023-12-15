using UserManagement.Domain.Aggregates;
using UserManagement.Domain.Repositories;
using UserManagement.Domain.ValueObjects;

namespace UserManagement.Infrastructure.Repositories;

public class UserCredentialsRepository : IUserCredentialsRepository
{
    public UserCredentials GetByEmailOrUsername(string emailOrUsername)
    {
        return _userCredentials.Single(u => u.Email.Value == emailOrUsername || u.Username.Value == emailOrUsername);
    }

    public void Save(UserCredentials userCredentials)
    {
        _userCredentials.RemoveAll(x => x.Id == userCredentials.Id);
        _userCredentials.Add(userCredentials);
    }
    
    private static UserCredentials Alice = new(
        1,
        Email.Create("alice@mail.com").Value,
        Username.Create("alice").Value,
        Password.Create("Password").Value
    );
    
    private static UserCredentials Bob = new(
        2,
        Email.Create("bob@mail.com").Value,
        Username.Create("bob").Value,
        Password.Create("Password").Value
    );
    
    private static readonly List<UserCredentials> _userCredentials = new()
    {
        Alice, Bob
    };
}