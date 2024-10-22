using AutoMapper;
using SweetDictionary.Models.Categories;
using SweetDictionary.Models.Entities;
using SweetDictionary.Models.Posts;


namespace SweetDictionary.Service.Mapings;

public class MappingProfiles : Profile
{
    public MappingProfiles()
    {
        CreateMap<CreatePostRequestDto,Post>().ReverseMap();
        CreateMap<Post, PostResponseDto>();
        CreateMap<UpdatePostRequestDto, Post>().ReverseMap();
        
        CreateMap<CreateCategoryRequestDto, Category>().ReverseMap();
        CreateMap<Category, CategoryResponseDto>();
        CreateMap<UpdateCategoryRequestDto, Category>().ReverseMap();
        
    }
}
