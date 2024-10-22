using Core.Entities;
using SweetDictionary.Models.Categories;

namespace SweetDictionary.Service.Abstracts;

public interface ICategoryService
{
    ReturnModel<CategoryResponseDto>Add(CreateCategoryRequestDto dto);
    ReturnModel<List<CategoryResponseDto>> GetAll();
    ReturnModel<CategoryResponseDto> GetById(int id);
    ReturnModel<CategoryResponseDto> Update(UpdateCategoryRequestDto dto);
    ReturnModel<string> Delete(int id);
    ReturnModel<List<CategoryResponseDto>> GetByName(string name);
    ReturnModel<List<CategoryResponseDto>> GetAllByNameContains(string text);
}

