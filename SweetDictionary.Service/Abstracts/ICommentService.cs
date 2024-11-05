using Core.Entities;
using SweetDictionary.Models.Comments;

namespace SweetDictionary.Service.Abstracts;

public interface ICommentService
{
    ReturnModel<List<CommentResponseDto>> GetAllCommentsByAuthorId(string authorId);
    ReturnModel<NoData> Add(string userId, CreateCommentRequestDto dto);
    ReturnModel<NoData> Update(string userId, UpdateCommentRequestDto dto);
    ReturnModel<List<CommentResponseDto>> GetAllByPostId(Guid id);
    ReturnModel<NoData>Delete(Guid id);
}