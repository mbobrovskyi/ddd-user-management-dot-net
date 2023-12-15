using Common.Domain;
using UserManagement.Domain.Aggregates;

namespace UserManagement.Domain.Repositories;

public interface IUserRepository
{
    User GetById(long id);
    User GetByEmailOrUsername(string emailOrUsername);
    IReadOnlyList<User> GetAll();
    void Save(User user);
}