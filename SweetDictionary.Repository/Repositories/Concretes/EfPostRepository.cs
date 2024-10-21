using Core.Repository;
using SweetDictionary.Models.Entities;
using SweetDictionary.Repository.Repositories.Abstracts;

namespace SweetDictionary.Repository.Repositories.Concretes;

public class EfPostRepository : EfRepositoryBase<BaseDbContext, Post, Guid>, IPostRepository
{
    public EfPostRepository(BaseDbContext context) : base(context)
    {
    }

    public List<Post> GetAllByCategoryId(int categoryId)
    {
        //select*from Posts where CategoryId = categoryId
        List<Post> posts = Context.Posts.Where(x => x.CategoryId == categoryId).ToList();
        return posts;
    }

    public List<Post> GetAllByAuthorId(long authorId)
    {
        //select*from Posts where AuthorId = authorId
        List<Post> posts = Context.Posts.Where(x => x.AuthorId == authorId).ToList();
        return posts;
    }

    public List<Post> GetAllByTitleContains(string text)
    {
        //select*from Posts where Title like '%text%'
        List<Post> posts = Context.Posts.Where(x => x.Title.Contains(text, StringComparison.CurrentCultureIgnoreCase)).ToList();
        return posts;
    }
}