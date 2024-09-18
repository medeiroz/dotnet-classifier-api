using ClassifierApi.Data;
using ClassifierApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ClassifierApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CategoryController(ApplicationDBContext context) : ControllerBase
{

  private readonly ApplicationDBContext _context = context;

  [HttpGet]
  public async Task<ActionResult<IEnumerable<Category>>> GetAll()
  {
    return await _context.Categories.ToListAsync();
  }


  [HttpGet("{id}")]
  public async Task<ActionResult<Category>> GetById(int id)
  {
    var record = await _context.Categories.FindAsync(id);

    if (record == null)
    {
      return NotFound();
    }

    return record;
  }

  [HttpPost]
  public async Task<ActionResult<Category>> Create(Category category)
  {
    category.Id = null;
    _context.Categories.Add(category);
    await _context.SaveChangesAsync();

    return CreatedAtAction(nameof(GetById), new { id = category.Id }, category);
  }

  [HttpPut("{id}")]
  public async Task<IActionResult> Update(int id, Category category)
  {
    if (id != category.Id)
    {
      return BadRequest();
    }

    _context.Entry(category).State = EntityState.Modified;

    try
    {
      await _context.SaveChangesAsync();
    }
    catch (DbUpdateConcurrencyException)
    {
      if (!await this.CategoryExists(id))
      {
        return NotFound();
      }
      else
      {
        throw;
      }
    }

    return NoContent();
  }

  [HttpDelete("{id}")]
  public async Task<IActionResult> Delete(int id)
  {
    var record = await _context.Categories.FindAsync(id);

    if (record == null)
    {
      return NotFound();
    }

    _context.Categories.Remove(record);
    await _context.SaveChangesAsync();

    return NoContent();
  }

  private async Task<bool> CategoryExists(int id)
  {
    return await _context.Categories.AnyAsync(e => e.Id == id);
  }
}
