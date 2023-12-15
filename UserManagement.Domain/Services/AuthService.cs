using UserManagement.Domain.Aggregates;
using UserManagement.Domain.Repositories;

namespace UserManagement.Domain.Services;

public class AuthService : IAuthService
{
    private readonly IUserRepository _userRepository;
    
    public AuthService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public void SignIn(string emailOrUsername, string password)
    {
        var user = _userRepository.GetByEmailOrUsername(emailOrUsername);
        if (user == null)
        {
            
        }
    }

    public void SignUp(User user)
    {
        throw new NotImplementedException();
    }

    public void SignOut()
    {
        throw new NotImplementedException();
    }
}