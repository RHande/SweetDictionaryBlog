using SweetDictionary.Models.Tokens;
using SweetDictionary.Models.Users;
using SweetDictionary.Service.Abstracts;

namespace SweetDictionary.Service.Concretes;

public class AuthenticationService : IAuthenticationService
{
    private readonly IUserService _userService;
    private readonly IJwtService _jwtService;
    
    public AuthenticationService(IUserService userService, IJwtService jwtService)
    {
        _userService = userService;
        _jwtService = jwtService;
    }
    
    public async Task<TokenResponseDto> RegisterByUserAsync(RegisterRequestDto registerDto)
    {
        var registerResponse = await _userService.CreateUserAsync(registerDto);
        var tokenResponse = await _jwtService.CreateToken(registerResponse);
        return tokenResponse;
    }

    public async Task<TokenResponseDto> LoginByUserAsync(LoginRequestDto loginDto)
    {
        var loginResponse = await _userService.LoginAsync(loginDto);
        var tokenResponse = _jwtService.CreateToken(loginResponse);
        return await tokenResponse;
    }
}