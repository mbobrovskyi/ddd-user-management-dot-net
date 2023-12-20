using UserManagement.Domain.Aggregates;
using UserManagement.Domain.ValueObjects;

namespace UserManagement.Domain.Repositories;

public interface IUserRepository
{
    User GetById(long id);
    User GetByEmail(Email email);
    IReadOnlyList<User> GetAll();
    User Save(User user);
}