namespace SweetDictionary.Models.Comments;

public sealed record CommentResponseDto
{
    public Guid Id { get; init; }
    public string Text { get; init; }
    public Guid PostId { get; init; }
    public long UserId { get; init; }
}