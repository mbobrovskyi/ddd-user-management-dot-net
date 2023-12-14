using UserManagement.Common;
using UserManagement.Domain.Entities;

namespace UserManagement.Domain;

public interface IUserRepository
{
    User GetByEmailOrUsername(string username);
}