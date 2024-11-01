using Microsoft.AspNetCore.Mvc;
using SweetDictionary.Models.Entities;
using SweetDictionary.Models.Users;
using SweetDictionary.Service.Abstracts;

namespace SweetDictionary.WebApi.Controllers;


[Route("api/[controller]")]
[ApiController]

public class UserController(IUserService _userService , IAuthenticationService _authenticationService) : ControllerBase
{
    [HttpPost("register")]
    public async Task<IActionResult> CreateUser([FromBody]RegisterRequestDto dto)
    {
        var result = await _authenticationService.RegisterByUserAsync(dto);
        return Ok(result);
    }
    
    [HttpGet("getbyemail")]
    public async Task<IActionResult> GetUserByEmail([FromQuery]string email)
    {
        User user = await _userService.GetByEmailAsync(email);
        return Ok(user);
    }
    
    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody]LoginRequestDto dto)
    {
        var result = await _authenticationService.LoginByUserAsync(dto);
        return Ok(result);
    }

    [HttpDelete("delete")]
    public async Task<IActionResult> Delete([FromQuery] string id)
    {
        var result = await _userService.DeleteAsync(id);
        return Ok(result);
    }
    
    [HttpPut("update")]
    public async Task<IActionResult> Update([FromQuery] string id, [FromBody] UpdateUserRequestDto dto)
    {
        var result = await _userService.UpdateAsync(id, dto);
        return Ok(result);
    }
    
    [HttpPut("changepassword")]
    public async Task<IActionResult> ChangePassword(string id, ChangePasswordRequestDto dto)
    {
        var result = await _userService.ChangePasswordAsync(id, dto);
        return Ok(result);
    }
    
    
}