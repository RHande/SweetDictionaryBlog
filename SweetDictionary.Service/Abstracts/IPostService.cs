using Core.Entities;
using SweetDictionary.Models.Posts;

namespace SweetDictionary.Service.Abstracts;

public interface IPostService
{
    Task<ReturnModel<PostResponseDto>> Add(CreatePostRequestDto dto, string authorId);
    ReturnModel<List<PostResponseDto>> GetAll();
    ReturnModel<PostResponseDto> GetById(Guid id);
    
    ReturnModel<PostResponseDto> Update(UpdatePostRequestDto dto);
    ReturnModel<string> Delete(Guid id);
    ReturnModel<List<PostResponseDto>> GetAllByCategoryId(int id);
    ReturnModel<List<PostResponseDto>> GetAllByAuthorId(string authorId);
    ReturnModel<List<PostResponseDto>> GetAllByTitleContains(string text);

}