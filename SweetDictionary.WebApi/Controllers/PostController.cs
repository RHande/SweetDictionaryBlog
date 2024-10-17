using Microsoft.AspNetCore.Mvc;
using SweetDictionary.Models.Posts;
using SweetDictionary.Service.Abstracts;

namespace SweetDictionary.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PostController(IPostService _postService):ControllerBase
{

    [HttpGet("getall")]
    public IActionResult GetALl()
    {
        var result = _postService.GetAll();
        return Ok(result);
    }
    
    
    [HttpPost("Add")]
    public IActionResult Add([FromBody]CreatePostRequestDto dto)
    {
        var result = _postService.Add(dto);
        return Ok(result);
    }
    
    
    [HttpGet("getbyid/{id:guid}")]
    public IActionResult GetById([FromRoute]Guid id)
    {
        var result = _postService.GetById(id);
        return Ok(result);
    }
    
}