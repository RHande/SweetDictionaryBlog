using Core.Repository;
using SweetDictionary.Models.Entities;
using SweetDictionary.Repository.Repositories.Abstracts;

namespace SweetDictionary.Repository.Repositories.Concretes;

public class EfCommentRepository : EfRepositoryBase<BaseDbContext, Comment, Guid>, ICommentRepository
{
    public EfCommentRepository(BaseDbContext context) : base(context)
    {
    }

    public List<Comment> GetAllByPostId(Guid postId)
    {
        //select*from Comments where PostId = postId
        List<Comment> comments = Context.Comments.Where(x => x.PostId == postId).ToList();
        return comments;
    }

    public List<Comment> GetAllByUserId(string userId)
    {
        //select*from Comments where UserId = userId
        List<Comment> comments = Context.Comments.Where(x => x.UserId == userId).ToList();
        return comments;
    }

    public List<Comment> GetAllByTextContains(string text)
    {
        //select*from Comments where Text like '%text%'
        List<Comment> comments = Context.Comments.Where(x => x.Text.Contains(text, StringComparison.CurrentCultureIgnoreCase)).ToList();
        return comments;
    }
}