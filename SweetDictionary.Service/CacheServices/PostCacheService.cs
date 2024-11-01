using System.Text.Json;
using Core.Exceptions;
using Microsoft.Extensions.Caching.Distributed;
using SweetDictionary.Models.Entities;

namespace SweetDictionary.Service.CacheServices;

public class PostCacheService (IDistributedCache cache)
{
    public async Task<Post> GetPostByIdAsync(Guid id)
    {
        string cacheKey = $"Post({id})";
        string cachedPost = await cache.GetStringAsync(cacheKey);
        // "{'id': değeri, 'title': değeri }"

        if (string.IsNullOrEmpty(cachedPost))
        {
            throw new BusinessException("İlgili post Cache de yok");
        }

        Post post = JsonSerializer.Deserialize<Post>(cachedPost);
        return post;
    }
    
    public async Task<Post> CreatePostAsync(Post post)
    {
        string cacheKey = $"Post({post.Id})";
        var serializePost = JsonSerializer.Serialize(post);

        var options = new DistributedCacheEntryOptions
        {
            AbsoluteExpirationRelativeToNow = TimeSpan.FromHours(1)
        };

        await cache.SetStringAsync(cacheKey,serializePost,options);

        return post;
    }


    // post(1): {'id': değeri, 'title': değeri }
    public async Task DeleteAsync(Guid id)
    {
        string cacheKey = $"Post({id})";
        await cache.RemoveAsync(cacheKey);

    }
}