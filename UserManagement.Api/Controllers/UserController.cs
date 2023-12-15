using Common.Api;
using Microsoft.AspNetCore.Mvc;
using UserManagement.Controllers.Mappers;
using UserManagement.Domain.Repositories;

namespace UserManagement.Controllers;

[Route("/users")]
public class UserController : BaseController
{
    private readonly IUserRepository _userRepository;

    public UserController(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    [HttpGet]
    public IActionResult GetList()
    {
        return Ok(_userRepository.GetAll().Select(UserMapper.UserToResponse));
    }
    
    [HttpGet("current")]
    public IActionResult Current ()
    {
        // TODO: Get id from session; 
        long id = 1;
        return Ok(UserMapper.UserToResponse(_userRepository.GetById(id)));
    }
    
    [HttpGet("{id}")]
    public IActionResult Get (long id)
    {
        return Ok(UserMapper.UserToResponse(_userRepository.GetById(id)));
    }
}