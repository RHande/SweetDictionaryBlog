using Core.Entities;
using SweetDictionary.Models.Posts;

namespace SweetDictionary.Service.Abstracts;

public interface IPostService
{
    ReturnModel<PostResponseDto> Add(CreatePostRequestDto dto);
    ReturnModel<List<PostResponseDto>> GetAll();
    ReturnModel<PostResponseDto> GetById(Guid id);
    
    ReturnModel<PostResponseDto> Update(UpdatePostRequestDto dto);
    ReturnModel<string> Delete(Guid id);
    ReturnModel<List<PostResponseDto>> GetAllByCategoryId(int CategoryId);
    ReturnModel<List<PostResponseDto>> GetAllByAuthorId(long AuthorId);
    ReturnModel<List<PostResponseDto>> GetAllByTitleContains(string text);

}