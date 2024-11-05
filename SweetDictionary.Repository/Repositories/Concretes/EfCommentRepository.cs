using Core.Repository;
using SweetDictionary.Models.Entities;
using SweetDictionary.Repository.Contexts;
using SweetDictionary.Repository.Repositories.Abstracts;

namespace SweetDictionary.Repository.Repositories.Concretes;

public class EfCommentRepository : EfRepositoryBase<BaseDbContext, Comment, Guid>, ICommentRepository
{
    public EfCommentRepository(BaseDbContext context) : base(context)
    {
    }
    
}