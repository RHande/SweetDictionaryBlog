using StackExchange.Redis;
using SweetDictionary.Models.Users;

namespace SweetDictionary.Service.Abstracts;

public interface IRoleService
{
   Task<string> AddRoleToUser(RoleAddToUserRequestDto dto);
   Task<List<string>> GetAllRolesByUserId(string userId);
   Task<string> AddRoleAsync(string roleName);
}