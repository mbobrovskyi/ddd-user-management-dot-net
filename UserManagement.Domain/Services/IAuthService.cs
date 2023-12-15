using UserManagement.Domain.Aggregates;

namespace UserManagement.Domain.Services;

public interface IAuthService
{
    void SignIn(string username, string password);
    void SignUp(User user);
    void SignOut();
}