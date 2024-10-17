using AutoMapper;
using SweetDictionary.Models.Entities;
using SweetDictionary.Models.Posts;


namespace SweetDictionary.Service.Mapings;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreatePostRequestDto,Post>().ReverseMap();
        CreateMap<Post, PostResponseDto>();
    }
}
