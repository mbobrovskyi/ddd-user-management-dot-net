using Common.Domain;
using UserManagement.Domain.Aggregates;
using UserManagement.Domain.Repositories;
using UserManagement.Domain.ValueObjects;

namespace UserManagement.Infrastructure.Repositories;

public class UserRepository : IUserRepository
{
    public User GetById(long id)
    {
        return Users.Single(u => u.Id == id);
    }

    public User GetByEmail(Email email)
    {
        return Users.Single(u => u.Email.Value == email.Value);
    }

    public IReadOnlyList<User> GetAll()
    {
        return Users;
    }

    public User Save(User user)
    {
        if (user.Id == 0)
        {
            _lastId++;
            SetId(user, _lastId);
        }

        Users.RemoveAll(x => x.Id == user.Id);
        Users.Add(user);

        return user;
    }

    private static void SetId(Entity entity, long id)
    {
        entity.GetType().GetProperty(nameof(Entity.Id))?.SetValue(entity, id);
    }

    private static readonly User Alice = new(
        1,
        Email.Create("alice@mail.com").Value,
        FirstName.Create("Alice").Value,
        LastName.Create("Alison").Value,
        DateTime.Now,
        DateTime.Now
    );
    
    private static readonly User Bob = new(
        2,
        Email.Create("bob@mail.com").Value,
        FirstName.Create("Bob").Value,
        LastName.Create("Bobson").Value,
        DateTime.Now, 
        DateTime.Now
    );
    
    private static readonly List<User> Users = new()
    {
        Alice, Bob
    };
    
    private static long _lastId = Users.Max(u => u.Id);
}