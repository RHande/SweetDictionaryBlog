namespace SweetDictionary.Models.Users;

public sealed record UpdateUserRequestDto(
    string Username, 
    DateTime BirthDate);