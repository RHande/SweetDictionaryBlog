namespace SweetDictionary.Models.Users;

public sealed record RegisterRequestDto(string Username, string FirstName, string LastName, string Email, string Password,
DateTime BirthDate);