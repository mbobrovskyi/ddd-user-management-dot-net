using UserManagement.Domain.Aggregates;
using UserManagement.Domain.ValueObjects;

namespace UserManagement.Domain.Repositories;

public interface IUserCredentialsRepository
{
    UserCredentials GetByEmailOrUsername(string emailOrUsername);
}