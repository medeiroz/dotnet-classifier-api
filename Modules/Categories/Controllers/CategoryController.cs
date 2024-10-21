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
  public async Task<IActionResult> GetById(string id)
  {
    try
    {
      var record = await _service.GetById(id);
      var response = ResponseCategoryDto.FromEntity(record);
      return Ok(response);
    }
    catch (RecordNotFoundException)
    {
      return NotFound();
    }
  }

  [HttpPost]
  public async Task<IActionResult> Create(CreateCategoryDto categoryDto)
  {
    var record = await _service.Create(categoryDto);

    return CreatedAtAction(nameof(Create), new { id = record._id }, record);
  }

  [HttpPut("{id}")]
  public async Task<IActionResult> Update(string id, UpdateCategoryDto categoryDto)
  {
    if (id == "")
    {
      return BadRequest();
    }

    try
    {
      await _service.Update(id, categoryDto);
      return Ok();
    }
    catch (RecordNotFoundException)
    {
      return NotFound();
    }
  }

  [HttpDelete("{id}")]
  public async Task<IActionResult> Delete(string id)
  {
    if (id == "")
    {
      return BadRequest();
    }

    try
    {
      await _service.Delete(id);
      return Ok();
    }
    catch (RecordNotFoundException)
    {
      return NotFound();
    }
  }
}
