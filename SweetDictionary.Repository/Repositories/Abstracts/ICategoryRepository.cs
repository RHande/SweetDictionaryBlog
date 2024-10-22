using Core.Repository;
using SweetDictionary.Models.Entities;

namespace SweetDictionary.Repository.Repositories.Abstracts;

public interface ICategoryRepository : IRepository<Category, int>
{
    Category GetByName(string name);
    List<Category> GetAllWithPosts();
    List<Category> GetAllByNameContains(string text);
}