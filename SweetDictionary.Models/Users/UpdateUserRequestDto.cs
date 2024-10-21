namespace SweetDictionary.Models.Users;

public sealed record UpdateUserRequestDto(long Id, string Username, string FirstName, string LastName, string Email, string Password);