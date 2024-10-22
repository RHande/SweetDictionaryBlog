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


    public async Task<User> CreateUserAsync(RegisterRequestDto registerRequestDto)
    {
        User user = new User
        {
            Id = Guid.NewGuid().ToString(),
            Email = registerRequestDto.Email,
            UserName = registerRequestDto.Username,
            BirthDate = registerRequestDto.BirthDate,
        };
        
        IdentityResult result = await _userManager.CreateAsync(user, registerRequestDto.Password);
        if (!result.Succeeded)
        {
            throw new Exception("User could not be created");
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
    
}