using SweetDictionary.Models.Tokens;
using SweetDictionary.Models.Users;

namespace SweetDictionary.Service.Abstracts;

public interface IAuthenticationService
{
    Task<TokenResponseDto> RegisterByUserAsync(RegisterRequestDto registerDto);
    Task<TokenResponseDto> LoginByUserAsync(LoginRequestDto loginDto);
}