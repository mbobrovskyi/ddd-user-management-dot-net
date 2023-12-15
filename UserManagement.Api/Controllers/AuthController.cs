using Common.Api;
using Microsoft.AspNetCore.Mvc;
using UserManagement.Controllers.DataContracts;
using UserManagement.Domain.Services;

namespace UserManagement.Controllers;

[Route("/auth")]
public class AuthController : BaseController
{
    private IAuthService _authService; 
    
    public AuthController(IAuthService authService)
    {
    _authService = authService;
    }
    
    [HttpPost("sign-in")]
    public IActionResult SignIn([FromBody] SignInRequest signInRequest)
    {
        return Ok();
    }
    
    [HttpPost("sign-up")]
    public IActionResult SignUp([FromBody] SignUpRequest signUpRequest)
    {
        return Ok();
    }
    
    [HttpPost("sign-out")]
    public IActionResult SignOut()
    {
        _authService.SignOut();
        return Ok();
    }
}