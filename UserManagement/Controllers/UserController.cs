using Microsoft.AspNetCore.Mvc;

namespace UserManagement.Controllers;

[ApiController]
[Route("/user")]
public class UserController : ControllerBase
{
    private readonly ILogger<UserController> _logger;

    public UserController(ILogger<UserController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetUsers")]
    public IEnumerable<UserDto> GetList()
    {
        return new List<UserDto>();
    }
}