using Core.Repository;
using SweetDictionary.Models.Entities;

namespace SweetDictionary.Repository.Repositories.Abstracts;

public interface ICommentRepository : IRepository<Comment, Guid>
{
    List<Comment> GetAllByPostId(Guid postId);
    List<Comment> GetAllByUserId(string userId);
    List<Comment> GetAllByTextContains(string text);
}