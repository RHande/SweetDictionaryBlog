using FluentValidation;
using SweetDictionary.Models.Users;

namespace SweetDictionary.Service.Validations.Users;

public class RegisterValidation :AbstractValidator<RegisterRequestDto>
{
    public RegisterValidation()
    {
        RuleFor(x=>x.Email).EmailAddress().WithMessage("Email is not valid");
        RuleFor(x=>x.Username).NotEmpty().WithMessage("Username is required");
        RuleFor(x=>x.Password).MinimumLength(6).WithMessage("Password must be at least 6 characters");
    }
}