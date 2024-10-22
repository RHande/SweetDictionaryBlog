using Core.Entities;
using SweetDictionary.Models.Comments;

namespace SweetDictionary.Service.Abstracts;

public interface ICommentService
{
    ReturnModel<CommentResponseDto> Add(CreateCommentRequestDto dto);
    ReturnModel<List<CommentResponseDto>> GetAll();
    ReturnModel<CommentResponseDto> GetById(Guid id);
    ReturnModel<CommentResponseDto> Update(UpdateCommentRequestDto dto);
    ReturnModel<string> Delete(Guid id);
    ReturnModel<List<CommentResponseDto>> GetAllByPostId(Guid postId);
    ReturnModel<List<CommentResponseDto>> GetAllByUserId(long userId);
    ReturnModel<List<CommentResponseDto>> GetAllByTextContains(string text);
}