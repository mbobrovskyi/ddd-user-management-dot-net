using UserManagement.Domain.Aggregates;
using UserManagement.Domain.ValueObjects;

namespace UserManagement.Domain.Repositories;

public interface IUserCredentialsRepository
{
    UserCredentials? GetByEmail(Email email);
    UserCredentials Save(UserCredentials userCredentials);
}