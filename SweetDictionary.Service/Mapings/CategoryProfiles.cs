using AutoMapper;
using SweetDictionary.Models.Categories;
using SweetDictionary.Models.Entities;


namespace SweetDictionary.Service.Mapings;

public class CategoryProfiles : Profile
{
    public CategoryProfiles()
    {
        CreateMap<CreateCategoryRequestDto, Category>();
        CreateMap<Category, CategoryResponseDto>();
        CreateMap<UpdateCategoryRequestDto, Category>().ReverseMap();
    }
}

