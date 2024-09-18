namespace ClassifierApi.Modules.Categories.Controllers;

using ClassifierApi.Exceptions;
using ClassifierApi.Modules.Categories.Dtos;
using ClassifierApi.Modules.Categories.Models;
using ClassifierApi.Modules.Categories.Repositories.Contracts;
using Microsoft.AspNetCore.Mvc;

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
  public async Task<ActionResult<Category>> GetById(int id)
  {
    try
    {
      return await _repository.GetByIdAsync(id);

    }
    catch (RecordNotFoundException)
    {
      return NotFound();
    }
  }

  [HttpPost]
  public async Task<ActionResult<Category>> Create(CreateCategoryDto categoryDto)
  {
    var entity = categoryDto.ToEntity();

    await _repository.StoreAsync(entity);

    return CreatedAtAction(nameof(GetById), new { id = entity.Id }, entity);
  }

  [HttpPut("{id}")]
  public async Task<IActionResult> Update(int id, UpdateCategoryDto categoryDto)
  {
    var entity = categoryDto.ToEntity();
    entity.Id = id;

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
  public async Task<IActionResult> Delete(int id)
  {
    if (id <= 0)
    {
      return BadRequest();
    }

    try
    {
      await _repository.DeleteAsync(id);
      return Ok();
    }
    catch (RecordNotFoundException)
    {
      return NotFound();
    }
  }
}
