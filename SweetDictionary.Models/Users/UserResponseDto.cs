namespace SweetDictionary.Models.Users;

public sealed record UserResponseDto(long Id, string Username, string FirstName, string LastName, string Email);