using Core.Exceptions;
using Microsoft.AspNetCore.Identity;
using SweetDictionary.Models.Entities;
using SweetDictionary.Models.Users;
using SweetDictionary.Service.Abstracts;

namespace SweetDictionary.Service.Concretes;

public class UserService : IUserService
{
    private readonly UserManager<User> _userManager;

    public UserService(UserManager<User> userManager)
    {
        _userManager = userManager;
    }


    public async Task<User> CreateUserAsync(RegisterRequestDto dto)
    {
        User user = new User
        {
            Email = dto.Email,
            UserName = dto.Username,
            BirthDate = dto.BirthDate,
        };

        var result = await _userManager.CreateAsync(user, dto.Password);
        if (!result.Succeeded)
        {
            throw new Exception("User could not be created");
        }
        var role = await _userManager.AddToRoleAsync(user, "User");
        if (!role.Succeeded)
        {
            throw new BusinessException(role.Errors.First().Description);
        }
        
        return user;
    }

    public async Task<User> GetByEmailAsync(string email)
    {
        var user = await _userManager.FindByEmailAsync(email);
        if (user is null)
        {
            throw new NotFoundException("User not found");
        }

        return user;
    }

    public async Task<User> LoginAsync(LoginRequestDto dto)
    {
        var userExist = await _userManager.FindByEmailAsync(dto.Email);
        UserIsPresent(userExist);
        
        var result = await _userManager.CheckPasswordAsync(userExist, dto.Password);
        if (!result)
        {
            throw new Exception("Password is wrong");
        }
        
        return userExist;
    }

    public async Task<string> DeleteAsync(string id)
    {
        var user = await _userManager.FindByIdAsync(id);
        UserIsPresent(user);
        await _userManager.DeleteAsync(user);
        return "User deleted successfully";
    }

    public async Task<User> UpdateAsync(string id, UpdateUserRequestDto dto)
    {
        var user = await _userManager.FindByIdAsync(id);
        UserIsPresent(user);
        
        user.UserName = dto.Username;
        user.BirthDate = dto.BirthDate;
        
        var result = await _userManager.UpdateAsync(user);
        if (!result.Succeeded)
        {
            throw new BusinessException(result.Errors.First().Description);
        }

        return user;
    }

    public async Task<string> ChangePasswordAsync(string id, ChangePasswordRequestDto dto)
    {
        var user = await _userManager.FindByIdAsync(id);
        UserIsPresent(user);
        
        var result = await _userManager.ChangePasswordAsync(user, dto.OldPassword, dto.NewPassword);
        if (!result.Succeeded)
        {
            throw new BusinessException(result.Errors.First().Description);
        }
        
        return "Password changed successfully";
    }

    private void UserIsPresent(User? user)
    {
        if (user is null)
        {
            throw new NotFoundException("User not found");
        }
    }
}