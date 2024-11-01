using AutoMapper;
using Core.Entities;
using SweetDictionary.Models.Entities;
using SweetDictionary.Models.Posts;
using SweetDictionary.Repository.Repositories.Abstracts;
using SweetDictionary.Service.Abstracts;
using SweetDictionary.Service.Constants;
using SweetDictionary.Service.Rules;

namespace SweetDictionary.Service.Concretes;

public class PostService : IPostService
{
    private readonly IPostRepository _postRepository;
    private readonly IMapper _mapper;
    private readonly PostBusinessRules _postBusinessRules;

    public PostService(IPostRepository postRepository,IMapper mapper, PostBusinessRules postBusinessRules)
    {
        _postRepository = postRepository;
        _mapper = mapper;
        _postBusinessRules = postBusinessRules;
    }

    public Task<ReturnModel<PostResponseDto>> Add(CreatePostRequestDto dto, string userId)
    {
        Post createdPost = _mapper.Map<Post>(dto);
        createdPost.Id = Guid.NewGuid();
        createdPost.AuthorId = userId;
        
        Post post = _postRepository.Add(createdPost);
        PostResponseDto response = _mapper.Map<PostResponseDto>(post);
        return Task.FromResult(new ReturnModel<PostResponseDto>()
        {
            Data = response,
            Message = Messages.PostAddedMessage,
            Status = 200,
            Success = true
        });
    }

    public ReturnModel<List<PostResponseDto>> GetAll()
    {
        var posts = _postRepository.GetAll();
        List<PostResponseDto> responses = _mapper.Map<List<PostResponseDto>>(posts);
        return new ReturnModel<List<PostResponseDto>>()
        {
            Data = responses,
            Message = Messages.PostFetchedMessage, //string.Empty de yazabiliriz. Bu mesaj vermediğimiz anlamına gelir.
            Status = 200,
            Success = true
        };
    }

    public ReturnModel<PostResponseDto> GetById(Guid id)
    {
        try
        {
            _postBusinessRules.PostIsPresent(id);
            Post? post = _postRepository.GetById(id);
            PostResponseDto response = _mapper.Map<PostResponseDto>(post);
            return new ReturnModel<PostResponseDto>()
            {
                Data = response,
                Message = Messages.PostFetchedMessage,
                Status = 200,
                Success = true
            };
        }
        catch (Exception e)
        {
            return ExceptionHandler<PostResponseDto>.HandleException(e);
        }
       
    }

    public ReturnModel<PostResponseDto> Update(UpdatePostRequestDto dto)
    {
        try
        {
            _postBusinessRules.PostIsPresent(dto.Id);

            Post? post = _postRepository.GetById(dto.Id);

            post.Title = dto.Title;
            post.Content = dto.Content;
            
            _postRepository.Update(post);
            PostResponseDto response = _mapper.Map<PostResponseDto>(post);
            
            return new ReturnModel<PostResponseDto>()
            {
                Data = response,
                Message = Messages.PostUpdatedMessage,
                Status = 200,
                Success = true
            };
        }
        catch (Exception e)
        {
            return ExceptionHandler<PostResponseDto>.HandleException(e);
        }
    }

    public ReturnModel<string> Delete(Guid id)
    {
        _postBusinessRules.PostIsPresent(id);
        
        
        Post? post = _postRepository.GetById(id);
        Post deletedPost = _postRepository.Delete(post);
        return new ReturnModel<string>()
        {
            Data = $"Post Title: {deletedPost.Title}",
            Message = Messages.PostDeletedMessage,
            Status = 200,
            Success = true
        };
    }

    public ReturnModel<List<PostResponseDto>> GetAllByCategoryId(int id)
    {
        List<Post> posts = _postRepository.GetAll(x=>x.CategoryId==id);
        List<PostResponseDto> responses = _mapper.Map<List<PostResponseDto>>(posts);
        return new ReturnModel<List<PostResponseDto>>()
        {
            Data = responses,
            Message = $"Posts fetched successfully by CategoryId: {id}",
            Status = 200,
            Success = true
        };
    }

    public ReturnModel<List<PostResponseDto>> GetAllByAuthorId(string authorId)
    {
        List<Post> posts = _postRepository.GetAll(p=>p.AuthorId==authorId);
        List<PostResponseDto> responses = _mapper.Map<List<PostResponseDto>>(posts);
        return new ReturnModel<List<PostResponseDto>>()
        {
            Data = responses,
            Message = $"Posts fetched successfully by AuthorId: {authorId}",
            Status = 200,
            Success = true
        };
    }

    public ReturnModel<List<PostResponseDto>> GetAllByTitleContains(string text)
    {
        var posts = _postRepository.GetAll(x=> x.Title.Contains(text));
        var responses = _mapper.Map<List<PostResponseDto>>(posts);
        return new ReturnModel<List<PostResponseDto>>()
        {
            Data = responses,
            Message = $"Posts fetched successfully by Title Contains: {text}",
            Status = 200,
            Success = true
        };
    }
}