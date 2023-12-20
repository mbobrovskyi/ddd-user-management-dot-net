using Common.Api;
using Microsoft.AspNetCore.Mvc;
using UserManagement.Controllers.DataContracts;
using UserManagement.Controllers.Mappers;
using UserManagement.Domain.Repositories;

namespace UserManagement.Controllers;

[Route("/users")]
public class UserController : ApiWithSessionController
{
    private readonly IUserRepository _userRepository;

    public UserController(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    [ProducesResponseType(typeof(IEnumerable<UserDto>), StatusCodes.Status200OK)]
    [HttpGet]
    public IActionResult GetList()
    {
        return Ok(_userRepository.GetAll().Select(UserMapper.UserToResponse));
    }
    
    [ProducesResponseType(typeof(UserDto), StatusCodes.Status200OK)]
    [HttpGet("current")]
    public IActionResult Current ()
    {
        return Ok(UserMapper.UserToResponse(_userRepository.GetById(GetUserId())));
    }
    
    [ProducesResponseType(typeof(UserDto), StatusCodes.Status200OK)]
    [HttpGet("{id}")]
    public IActionResult Get (long id)
    {
        return Ok(UserMapper.UserToResponse(_userRepository.GetById(id)));
    }
}