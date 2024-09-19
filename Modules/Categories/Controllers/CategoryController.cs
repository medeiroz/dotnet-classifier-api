using ClassifierApi.Exceptions;
using ClassifierApi.Modules.Categories.Dtos;
using ClassifierApi.Modules.Categories.Models;
using ClassifierApi.Modules.Categories.Repositories;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson;

namespace ClassifierApi.Modules.Categories.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoryController(ICategoryRepository repository) : ControllerBase
{

  private readonly ICategoryRepository _repository = repository;

  [HttpGet]
  public async Task<ActionResult<IEnumerable<Category>>> GetAll()
  {
    var records = await _repository.GetAllAsync();
    return Ok(records);
  }


  [HttpGet("{id}")]
  public async Task<ActionResult<Category>> GetById(string Id)
  {
    try
    {
      return await _repository.GetByIdAsync(new ObjectId(Id));
    }
    catch (RecordNotFoundException)
    {
      return NotFound();
    }
  }

  [HttpPost]
  public async Task<ActionResult<Category>> Create(CreateCategoryDto CategoryDto)
  {
    var entity = CategoryDto.ToEntity();

    await _repository.StoreAsync(entity);

    return CreatedAtAction(nameof(GetById), new { id = entity._id }, entity);
  }

  [HttpPut("{id}")]
  public async Task<IActionResult> Update(string Id, UpdateCategoryDto CategoryDto)
  {
    if (Id == "")
    {
      return BadRequest();
    }

    var entity = CategoryDto.ToEntity();
    entity._id = new ObjectId(Id);

    try
    {
      await _repository.UpdateAsync(entity);
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
      await _repository.DeleteAsync(new ObjectId(Id));
      return Ok();
    }
    catch (RecordNotFoundException)
    {
      return NotFound();
    }
  }
}
