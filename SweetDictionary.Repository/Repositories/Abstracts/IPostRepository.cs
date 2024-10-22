using Core.Repository;
using SweetDictionary.Models.Entities;

namespace SweetDictionary.Repository.Repositories.Abstracts;

public interface IPostRepository : IRepository<Post, Guid>
{
    
}