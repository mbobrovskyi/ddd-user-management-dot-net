using Common.Domain;
using UserManagement.Domain.Aggregates;
using UserManagement.Domain.Repositories;
using UserManagement.Domain.ValueObjects;

namespace UserManagement.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{

    public User GetById(long id)
    {
        return _users.Single(u => u.Id == id);
    }

    public User GetByEmailOrUsername(string emailOrUsername)
    {
        return _users.Single(u => u.Email.Value == emailOrUsername || u.Username.Value == emailOrUsername);
    }

    public IReadOnlyList<User> GetAll()
    {
        return _users;
    }

    public void Save(User user)
    {
        if (user.Id == 0)
        {
            _lastId++;
            SetId(user, _lastId);
        }

        _users.RemoveAll(x => x.Id == user.Id);
        _users.Add(user);
    }

    private static void SetId(Entity entity, long id)
    {
        entity.GetType().GetProperty(nameof(Entity.Id))?.SetValue(entity, id);
    }

    private static User Alice = new User(
        Email.Create("alice@mail.com").Value,
        Username.Create("alice").Value,
        FirstName.Create("Alice").Value,
        LastName.Create("Alison").Value,
        DateTime.Now,
        DateTime.Now,
        1
    );
    
    private static User Bob = new User(
        Email.Create("bob@mail.com").Value,
        Username.Create("bob").Value,
        FirstName.Create("Bob").Value,
        LastName.Create("Bobson").Value,
        DateTime.Now, 
        DateTime.Now,
        2
    );
    
    private static readonly List<User> _users = new List<User>
    {
        Alice, Bob
    };
    
    private static long _lastId = _users.Max(u => u.Id);
}