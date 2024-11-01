namespace SweetDictionary.Models.Users;

public sealed record LoginRequestDto (
    string Email, 
    string Password);