namespace SweetDictionary.Models.Users;

public sealed record CreateUserRequestDto(string Username, string FirstName, string LastName, string Email, string Password);