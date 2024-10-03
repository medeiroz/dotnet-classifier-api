using ClassifierApi.Exceptions;
using ClassifierApi.Modules.Categories.Dtos;
using ClassifierApi.Modules.Categories.Services;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;

namespace ClassifierApi.Modules.Categories.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoryController(ICategoryService service) : ControllerBase
{

  private readonly ICategoryService _service = service;

  [HttpGet]
  public async Task<IActionResult> GetAll()
  {
    var records = await _service.GetAll();
    return Ok(records);
  }


  [HttpGet("{id}")]
  public async Task<IActionResult> GetById(string Id)
  {
    try
    {
      var record = await _service.GetById(Id);
      return Ok(record);
    }
    catch (RecordNotFoundException)
    {
      return NotFound();
    }
  }

  [HttpPost]
  public async Task<IActionResult> Create(CreateCategoryDto CategoryDto)
  {
    var record = await _service.Create(CategoryDto);

    return CreatedAtAction(nameof(Create), new { id = record._id }, record);
  }

  [HttpPut("{id}")]
  public async Task<IActionResult> Update(string Id, UpdateCategoryDto CategoryDto)
  {
    if (Id == "")
    {
      return BadRequest();
    }

    try
    {
      await _service.Update(Id, CategoryDto);
      return Ok();
    }
    catch (RecordNotFoundException)
    {
      return NotFound();
    }
  }

  [HttpDelete("{id}")]
  public async Task<IActionResult> Delete(string Id)
  {
    if (Id == "")
    {
      return BadRequest();
    }

    try
    {
      await _service.Delete(Id);
      return Ok();
    }
    catch (RecordNotFoundException)
    {
      return NotFound();
    }
  }
}
