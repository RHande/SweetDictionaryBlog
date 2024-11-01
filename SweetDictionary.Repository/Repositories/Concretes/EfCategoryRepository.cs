using Core.Repository;
using Microsoft.EntityFrameworkCore;
using SweetDictionary.Models.Entities;
using SweetDictionary.Repository.Contexts;
using SweetDictionary.Repository.Repositories.Abstracts;

namespace SweetDictionary.Repository.Repositories.Concretes;

public class EfCategoryRepository : EfRepositoryBase<BaseDbContext, Category, int>, ICategoryRepository
{
    public EfCategoryRepository(BaseDbContext context) : base(context)
    {
    }

    public Category GetByName(string name)
    {
        Category category = Context.Categories.FirstOrDefault(x => x.Name == name);
        return category;
    }

    public List<Category> GetAllWithPosts()
    {
        List<Category> categories = Context.Categories.Include(x => x.Posts).ToList();
        return categories;
    }

    public List<Category> GetAllByNameContains(string text)
    {
        List<Category> categories = Context.Categories.Where(x => x.Name.Contains(text, StringComparison.CurrentCultureIgnoreCase)).ToList();
        return categories;
    }
}