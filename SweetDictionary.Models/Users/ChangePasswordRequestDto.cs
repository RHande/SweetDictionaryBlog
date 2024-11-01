namespace SweetDictionary.Models.Users;

public sealed record ChangePasswordRequestDto(
    string OldPassword,
    string NewPassword);