using Core.Repository;
using SweetDictionary.Models.Entities;

namespace SweetDictionary.Repository.Repositories.Abstracts;

public interface ICommentRepository : IRepository<Comment, Guid>
{
    
}