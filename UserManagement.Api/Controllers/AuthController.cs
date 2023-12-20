using Common.Api;
using Microsoft.AspNetCore.Mvc;
using UserManagement.Controllers.DataContracts;
using UserManagement.Domain.Aggregates;
using UserManagement.Domain.Repositories;
using UserManagement.Domain.ValueObjects;

namespace UserManagement.Controllers;

[Route("/auth")]
public class AuthController : ApiController
{
    private IUserRepository _userRepository;
    private IUserCredentialsRepository _userCredentialsRepository;
    
    public AuthController(IUserRepository userRepository, IUserCredentialsRepository userCredentialsRepository)
    {
        _userRepository = userRepository;
        _userCredentialsRepository = userCredentialsRepository;
    }
    
    [ProducesResponseType(typeof(TokenDto), StatusCodes.Status200OK)]
    [HttpPost("sign-in")]
    public IActionResult SignIn([FromBody] SignInRequest request)
    {
        if (_userCredentialsRepository.GetByEmail(Email.Create(request.Email).Value) == null)
        {
            return Unauthorized();
        }
        
        return Ok();
    }
    
    [ProducesResponseType(typeof(TokenDto), StatusCodes.Status200OK)]
    [HttpPost("sign-up")]
    public IActionResult SignUp([FromBody] SignUpRequest signUpRequest)
    {
        var user = new User(
            Email.Create(signUpRequest.Email).Value,
            FirstName.Create(signUpRequest.FirstName).Value,
            LastName.Create(signUpRequest.LastName).Value);
        _userRepository.Save(user);
        
        return Ok();
    }
    
    [ProducesResponseType(StatusCodes.Status200OK)]
    [HttpPost("sign-out")]
    public IActionResult SignOut()
    {
        return Ok();
    }
}