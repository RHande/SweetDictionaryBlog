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

    [HttpPut("update")]
    public IActionResult Update([FromBody] UpdatePostRequestDto dto)
    {
        var result = _postService.Update(dto);
        return Ok(result);
    }
    
    [HttpDelete("delete/{id:guid}")]
    public IActionResult Delete([FromRoute]Guid id)
    {
        var result = _postService.Delete(id);
        return Ok(result);
    }

    [HttpGet("getallbycategoryid/{id:int}")]
    public IActionResult GetAllByCategoryId(int id)
    {
        var result = _postService.GetAllByCategoryId(id);
        return Ok(result);
    }
    
    
    [HttpGet("getallbyauthorid/{id:long}")]
    public IActionResult GetAllByAuthorId(long id)
    {
        var result = _postService.GetAllByAuthorId(id);
        return Ok(result);
    }
    
    [HttpGet("getallbytitlecontains/{title}")]
    public IActionResult GetAllByTitleContains(string title)
    {
        var result = _postService.GetAllByTitleContains(title);
        return Ok(result);
    }
    
}