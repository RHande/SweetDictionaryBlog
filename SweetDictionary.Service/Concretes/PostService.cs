using AutoMapper;
using Core.Entities;
using SweetDictionary.Models.Entities;
using SweetDictionary.Models.Posts;
using SweetDictionary.Repository.Repositories.Abstracts;
using SweetDictionary.Service.Abstracts;

namespace SweetDictionary.Service.Concretes;

public class PostService : IPostService
{
    private readonly IPostRepository _postRepository;
    private readonly IMapper _mapper;

    public PostService(IPostRepository postRepository,IMapper mapper)
    {
        _postRepository = postRepository;
        _mapper = mapper;
    }

    public ReturnModel<PostResponseDto> Add(CreatePostRequestDto dto)
    {
        Post createdPost = _mapper.Map<Post>(dto);
        createdPost.Id = Guid.NewGuid();
        
        Post post = _postRepository.Add(createdPost);
        PostResponseDto response = _mapper.Map<PostResponseDto>(post);
        return new ReturnModel<PostResponseDto>()
        {
            Data = response,
            Message = "Post created successfully",
            Status = 200,
            Success = true
        };
    }

    public ReturnModel<List<PostResponseDto>> GetAll()
    {
        var posts = _postRepository.GetAll();
        List<PostResponseDto> responses = _mapper.Map<List<PostResponseDto>>(posts);
        return new ReturnModel<List<PostResponseDto>>()
        {
            Data = responses,
            Message = "Posts fetched successfully", //string.Empty de yazabiliriz. Bu mesaj vermediğimiz anlamına gelir.
            Status = 200,
            Success = true
        };
    }

    public ReturnModel<PostResponseDto> GetById(Guid id)
    {
        var post = _postRepository.GetById(id);
        if (post == null)
        {
            return new ReturnModel<PostResponseDto>()
            {
                Data = null,
                Message = "Post not found",
                Status = 404,
                Success = false
            };
        }
        var response = _mapper.Map<PostResponseDto>(post);
        return new ReturnModel<PostResponseDto>()
        {
            Data = response,
            Message = "Post fetched successfully",
            Status = 200,
            Success = true
        };
    }
}