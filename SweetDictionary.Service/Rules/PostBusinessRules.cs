using Core.Exceptions;
using SweetDictionary.Repository.Repositories.Abstracts;

namespace SweetDictionary.Service.Rules;

public class PostBusinessRules(IPostRepository _postRepository)
{
    public virtual bool PostIsPresent(Guid id)
    {
        var post = _postRepository.GetById(id);
        if (post == null)
        {
            throw new NotFoundException($"Post not found according to the given id : {id}");
        }
        
        return true;
    }
    
    public void PostTitleIsUnique(string title)
    {
        var post = _postRepository.GetAll(x => x.Title == title);
        if (post.Count > 0)
        {
            throw new BusinessException("Post title is must be unique");
        }
    }
}