using System.Runtime.CompilerServices;
using AutoMapper;
using Core.Exceptions;
using Moq;
using SweetDictionary.Models.Entities;
using SweetDictionary.Models.Posts;
using SweetDictionary.Repository.Repositories.Abstracts;
using SweetDictionary.Service.Concretes;
using SweetDictionary.Service.Constants;
using SweetDictionary.Service.Rules;

namespace Service.Test;

public class PostServiceTest
{
    private PostService _postService;
    
    //Mock'ladığmızda sanal bir repository oluşturmuş oluyoruz.
    private Mock<IPostRepository> _mockRepository;
    private Mock<IMapper> _mockMapper;
    private Mock<PostBusinessRules> _mockRules;
    
    [SetUp] //Unit test çalışırken ilk çalışan metot
    public void Setup()
    {
        _mockRepository = new Mock<IPostRepository>();
        _mockMapper = new Mock<IMapper>();
        _mockRules = new Mock<PostBusinessRules>(_mockRepository.Object);
        
        _postService = new PostService(_mockRepository.Object, _mockMapper.Object, _mockRules.Object);
    }
    
    [Test]
    public async Task PostService_WhenPostAdded_ReturnSuccess()
    {
        CreatePostRequestDto dto = new CreatePostRequestDto("deneme", "deneme", 1);
        Post post = new Post
        {
            Title = dto.Title,
            Content = dto.Content,
            CategoryId = dto.CategoryId
        };
        
        PostResponseDto response = new PostResponseDto
        {
            AuthorFirstName = "deneme",
            CategoryName = "deneme",
            Content = "deneme",
            Id = new Guid( "00000000-0000-0000-0000-000000000000"),
            Title = "deneme"
        };
        //Arrange
        _mockMapper.Setup(x=>x.Map<Post>(dto)).Returns(post);
        _mockRepository.Setup(x=>x.Add(post)).Returns(post);
        _mockMapper.Setup(x=>x.Map<PostResponseDto>(post)).Returns(response);
        
        //Act
        var result =  await _postService.Add(dto, "10000000-0000-0000-0000-000000000000");
        
        
        //Assert
        Assert.IsTrue(result.Success);
        Assert.That(response, Is.EqualTo(result.Data));

    }
    
    
    [Test]
    public void PostService_WhenPostIsPresent_RemovePost()
    {
        Guid id = new Guid("{BEF23537-D755-4B37-8A99-831089A5D0F1}");
        Post post = new Post
        {
            Id = id,
            Title = "dto.Title",
            Content = "dto.Content",
            CategoryId = 1,
            AuthorId = "10000000-0000-0000-0000-000000000000",
            CreatedTime = DateTime.Now,
            UpdatedTime = DateTime.Now,
        };
        
        //Arrange
        _mockRules.Setup(x=>x.PostIsPresent(id)).Returns(true);
        _mockRepository.Setup(x=>x.GetById(id)).Returns(post);
        _mockRepository.Setup(x=>x.Delete(post)).Returns(post);
        
        
        //Act
        var result = _postService.Delete(id);
        
        
        //Assert
        Assert.IsTrue(result.Success);

    }

    [Test]
    public void PostService_WhenPostIsPresent_RemoveFailed()
    {
        //Arrange
        Guid id = new Guid("{BEF23537-D755-4B37-8A99-831089A5D0F1}");
        _mockRules.Setup(x => x.PostIsPresent(id)).Throws(new NotFoundException($"Post not found according to the given id : {id}"));
        
        
        //Assert
        Assert.Throws<NotFoundException>(() => _postService.Delete(id), Messages.PostIsNotPresentMessage(id));
    }

    [Test]
    public void PostService_WhenPostIsPresent_GetById()
    {
        Guid id = new Guid("{BEF23537-D755-4B37-8A99-831089A5D0F1}");
        _mockRules.Setup(x => x.PostIsPresent(id)).Returns(true);
        
        
        //Assert
        Assert.DoesNotThrow(() => _postService.GetById(id));
    }

    [Test]
    public void PostService_WhenGetAllByContainsFilter_ReturnsList()
    {
        string text = "deneme";
        var posts = new List<Post>
        {
            new Post { Content = text, Title = "sample post 1" },
            new Post { Content = text, Title = "another sample post" }
        };
        
        var postResponseDtos = new List<PostResponseDto>
        {
            new PostResponseDto { Content = text, Title = "sample post 1" },
            new PostResponseDto { Content = text, Title = "another sample post" }
        };
        
        
        _mockRepository.Setup(x=>x.GetAll(x=>x.Title.Contains(text))).Returns(posts);
        _mockMapper.Setup(x=>x.Map<List<PostResponseDto>>(posts)).Returns(postResponseDtos);
        
        //Act
        var result = _postService.GetAllByTitleContains(text);
        
        //Assert
        Assert.That(result.Data, Is.EqualTo(postResponseDtos));
        Assert.IsTrue(result.Success);
        Assert.That(result.Status, Is.EqualTo(200));
    }
    
}