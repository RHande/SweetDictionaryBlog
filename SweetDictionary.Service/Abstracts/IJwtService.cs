using SweetDictionary.Models.Entities;
using SweetDictionary.Models.Tokens;

namespace SweetDictionary.Service.Abstracts;

public interface IJwtService
{
    Task<TokenResponseDto> CreateToken(User user);
}