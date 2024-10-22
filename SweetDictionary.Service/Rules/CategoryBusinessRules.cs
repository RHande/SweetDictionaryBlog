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
}