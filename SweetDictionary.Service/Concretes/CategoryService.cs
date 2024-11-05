using AutoMapper;
using Core.Entities;
using Core.Exceptions;
using SweetDictionary.Models.Categories;
using SweetDictionary.Models.Entities;
using SweetDictionary.Repository.Repositories.Abstracts;
using SweetDictionary.Service.Abstracts;
using SweetDictionary.Service.Constants;
using SweetDictionary.Service.Rules;

namespace SweetDictionary.Service.Concretes;

public class CategoryService : ICategoryService
{
    private readonly ICategoryRepository _categoryRepository;
    private readonly IMapper _mapper;
    private readonly CategoryBusinessRules _categoryBusinessRules;
    
    public CategoryService(ICategoryRepository categoryRepository, IMapper mapper, CategoryBusinessRules categoryBusinessRules)
    {
        _categoryRepository = categoryRepository;
        _mapper = mapper;
        _categoryBusinessRules = categoryBusinessRules;
    }
    
    
    public ReturnModel<CategoryResponseDto> Add(CreateCategoryRequestDto dto)
    {
        Category createdCategory = _mapper.Map<Category>(dto);
        Category category = _categoryRepository.Add(createdCategory);
        CategoryResponseDto response = _mapper.Map<CategoryResponseDto>(category);
        return new ReturnModel<CategoryResponseDto>()
        {
            Data = response,
            Message = Messages.CategoryAddedMessage,
            Status = 200,
            Success = true
        };
    }

    public ReturnModel<List<CategoryResponseDto>> GetAll()
    {
        _categoryBusinessRules.CategoryListIsNotEmpty();
        List<Category> categories = _categoryRepository.GetAll();
        List<CategoryResponseDto> response = _mapper.Map<List<CategoryResponseDto>>(categories);
        return new ReturnModel<List<CategoryResponseDto>>()
        {
            Data = response,
            Message = Messages.CategoryFetchedMessage,
            Status = 200,
            Success = true
        };
    }

    public ReturnModel<CategoryResponseDto> GetById(int id)
    {
            _categoryBusinessRules.CategoryIsPresent(id);
            Category? category = _categoryRepository.GetById(id);
            CategoryResponseDto response = _mapper.Map<CategoryResponseDto>(category);
            return new ReturnModel<CategoryResponseDto>()
            {
                Data = response,
                Message = Messages.CategoryFetchedMessage,
                Status = 200,
                Success = true
            };
    }

    public ReturnModel<CategoryResponseDto> Update(UpdateCategoryRequestDto dto)
    {
            _categoryBusinessRules.CategoryIsPresent(dto.Id);
            Category? category = _categoryRepository.GetById(dto.Id);
            category.Name = dto.Name;
            _categoryRepository.Update(category);
            CategoryResponseDto response = _mapper.Map<CategoryResponseDto>(category);
            return new ReturnModel<CategoryResponseDto>()
            {
                Data = response,
                Message = Messages.CategoryUpdatedMessage,
                Status = 200,
                Success = true
            };
    }

    public ReturnModel<string> Delete(int id)
    {
        
            Category? category = _categoryRepository.GetById(id);
            Category deletedCategory = _categoryRepository.Delete(category);
            return new ReturnModel<string>()
            {
                Data = $"Category Name: {deletedCategory.Name}",
                Message = Messages.CategoryDeletedMessage,
                Status = 200,
                Success = true
            };
    }

    public ReturnModel<List<CategoryResponseDto>> GetByName(string name)
    {
        List<Category> categories = _categoryRepository.GetAll(x=>x.Name == name);
        List<CategoryResponseDto> response = _mapper.Map<List<CategoryResponseDto>>(categories);
        return new ReturnModel<List<CategoryResponseDto>>()
        {
            Data = response,
            Message = Messages.CategoryFetchedMessage,
            Status = 200,
            Success = true
        };
    }
    

    public ReturnModel<List<CategoryResponseDto>> GetAllByNameContains(string text)
    {
        List<Category> categories = _categoryRepository.GetAll(x=>x.Name.Contains(text));
        List<CategoryResponseDto> response = _mapper.Map<List<CategoryResponseDto>>(categories);
        return new ReturnModel<List<CategoryResponseDto>>()
        {
            Data = response,
            Message = Messages.CategoryFetchedMessage,
            Status = 200,
            Success = true
        };
    }
}