namespace SweetDictionary.Models.Comments;

public sealed record CommentResponseDto(Guid Id, string Text, Guid PostId, long UserId);