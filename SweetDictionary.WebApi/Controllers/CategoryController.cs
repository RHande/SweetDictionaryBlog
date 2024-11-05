using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SweetDictionary.Models.Categories;
using SweetDictionary.Service.Abstracts;

namespace SweetDictionary.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]

public class CategoryController(ICategoryService _categoryService) : ControllerBase
{
    
    [HttpGet("getall")]
    public IActionResult GetAll()
    {
        var result = _categoryService.GetAll();
        return Ok(result);
    }
    
    
    
    [HttpPost("Add")]
    [Authorize(Roles = "Admin")]
    public IActionResult Add([FromBody]CreateCategoryRequestDto dto)
    {
        var result = _categoryService.Add(dto);
        return Ok(result);
    }
    
    
    [HttpGet("getbyid/{id:int}")]
    public IActionResult GetById([FromRoute]int id)
    {
        var result = _categoryService.GetById(id);
        return Ok(result);
    }
    
    
    [HttpPut("update")]
    [Authorize(Roles = "Admin")]
    public IActionResult Update([FromBody] UpdateCategoryRequestDto dto)
    {
        var result = _categoryService.Update(dto);
        return Ok(result);
    }
    
    
    [HttpDelete("delete/{id:int}")]
    [Authorize(Roles = "Admin")]
    public IActionResult Delete([FromRoute]int id)
    {
        var result = _categoryService.Delete(id);
        return Ok(result);
    }
    
    
    [HttpGet("getbyname/{name}")]
    public IActionResult GetByName([FromRoute]string name)
    {
        var result = _categoryService.GetByName(name);
        return Ok(result);
    }
    
    
    [HttpGet("getallbynamecontains/{name}")]
    public IActionResult GetAllByNameContains([FromRoute]string name)
    {
        var result = _categoryService.GetAllByNameContains(name);
        return Ok(result);
    }
    
}