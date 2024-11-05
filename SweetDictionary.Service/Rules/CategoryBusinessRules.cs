using Core.Exceptions;
using SweetDictionary.Repository.Repositories.Abstracts;

namespace SweetDictionary.Service.Rules;

public class CategoryBusinessRules(ICategoryRepository _categoryRepository)
{
    public void CategoryIsPresent(int id)
    {
        var category = _categoryRepository.GetById(id);
        if (category == null)
        {
            throw new NotFoundException($"Category not found according to the given id : {id}");
        }
    }
    
    public void CategoryListIsNotEmpty()
    {
        var categories = _categoryRepository.GetAll();
        if (categories.Count == 0)
        {
            throw new NotFoundException("There is no category in the system.");
        }
    }
}