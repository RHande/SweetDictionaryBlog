using Core.Entities;
using SweetDictionary.Models.Posts;

namespace SweetDictionary.Service.Abstracts;

public interface IPostService
{
    ReturnModel<PostResponseDto> Add(CreatePostRequestDto dto);
    ReturnModel<List<PostResponseDto>> GetAll();
    ReturnModel<PostResponseDto> GetById(Guid id);
}