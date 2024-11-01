using Core.Entities;
using SweetDictionary.Models.Entities;
using SweetDictionary.Models.Users;

namespace SweetDictionary.Service.Abstracts;

public interface IUserService
{
    Task<User> CreateUserAsync(RegisterRequestDto dto);
    Task<User> GetByEmailAsync(string email);
    Task<User> LoginAsync(LoginRequestDto dto);
    Task<string> DeleteAsync(string id);
    Task<User> UpdateAsync(string id, UpdateUserRequestDto dto);
    Task<string> ChangePasswordAsync(string id, ChangePasswordRequestDto dto);
}