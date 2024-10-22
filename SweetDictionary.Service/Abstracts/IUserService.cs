using Core.Entities;
using SweetDictionary.Models.Entities;
using SweetDictionary.Models.Users;

namespace SweetDictionary.Service.Abstracts;

public interface IUserService
{
    Task<User> CreateUserAsync(RegisterRequestDto registerRequestDto);
    Task<User> GetByEmailAsync(string email);
}