namespace SweetDictionary.Models.Comments;

public sealed record CommentResponseDto
{
    public string Text { get; init; }
    public string PostTitle { get; init; }
    public string UserName { get; init; }
}