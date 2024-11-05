using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SweetDictionary.Models.Posts;
using SweetDictionary.Service.Abstracts;



namespace SweetDictionary.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
[Authorize]
public class PostController(IPostService _postService):ControllerBase
{

    [HttpGet("getall")]
    [Authorize(Roles = "User")]
    public IActionResult GetALl()
    {
        var result = _postService.GetAll();
        return Ok(result);
    }
    
    [HttpPost("add")]
    public async Task<IActionResult> Add([FromBody]CreatePostRequestDto dto)
    {
        //Kullanıcının token id alanından alınması:
       string? authorId = HttpContext.User.Claims.FirstOrDefault(x => x.Type == ClaimTypes.NameIdentifier)?.Value;
       if (authorId == null)
       {
           return Unauthorized("Author ID not found in token."); 
       } 
       var result = await _postService.Add(dto, authorId);
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
    
    
    [HttpGet("getallbyauthorid/{id}")]
    public IActionResult GetAllByAuthorId(string id)
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