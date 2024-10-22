using Microsoft.AspNetCore.Mvc;
using SweetDictionary.Models.Entities;
using SweetDictionary.Models.Users;
using SweetDictionary.Service.Abstracts;

namespace SweetDictionary.WebApi.Controllers;


[Route("api/[controller]")]
[ApiController]

public class UserController(IUserService _userService) : ControllerBase
{
    [HttpPost("register")]
    public async Task<IActionResult> CreateUser([FromBody]RegisterRequestDto dto)
    {
        User user = await _userService.CreateUserAsync(dto);
        return Ok(user);
    }
    
    [HttpGet("getbyemail")]
    public async Task<IActionResult> GetUserByEmail([FromQuery]string email)
    {
        User user = await _userService.GetByEmailAsync(email);
        return Ok(user);
    }
    
    
}