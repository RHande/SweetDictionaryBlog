namespace SweetDictionary.Models.Tokens;

public sealed class TokenResponseDto
{
    public string AccessToken { get; set; }
    public DateTime AccessTokenExpiration { get; set; }
    
}