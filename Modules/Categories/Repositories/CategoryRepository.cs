using System.Collections.Generic;
using System.Threading.Tasks;
using ClassifierApi.Data;
using ClassifierApi.Exceptions;
using ClassifierApi.Modules.Categories.Models;
using Microsoft.EntityFrameworkCore;
using MongoDB.Bson;

namespace ClassifierApi.Modules.Categories.Repositories;

public class CategoryRepository(ApplicationDBContext context) : ICategoryRepository
{

  private readonly ApplicationDBContext _context = context;

  public async Task<IEnumerable<Category>> GetAllAsync()
  {
    return await _context.Categories.ToListAsync();
  }

  public async Task<Category> GetByIdAsync(ObjectId id)
  {
    var record = await _context.Categories.FindAsync(id);

    return record ?? throw new RecordNotFoundException($"Category {id} not found");
  }

  public async Task<int> StoreAsync(Category category)
  {
    _context.Categories.Add(category);
    return await _context.SaveChangesAsync();
  }

  public async Task<int> UpdateAsync(Category category)
  {
    var recordExists = await this.ExistsAsync(category._id);

    if (!recordExists)
    {
      throw new RecordNotFoundException($"Category {category._id} not found");
    }

    _context.Entry(category).State = EntityState.Modified;

    return await _context.SaveChangesAsync();
  }

  public async Task<int> DeleteAsync(ObjectId id)
  {
    var record = await _context.Categories.FindAsync(id);

    if (record == null)
    {
      throw new RecordNotFoundException($"Category {id} not found");
    }

    _context.Categories.Remove(record);
    return await _context.SaveChangesAsync();
  }

  public async Task<bool> ExistsAsync(ObjectId? id)
  {
    if (id == null)
    {
      return false;
    }

    return await _context.Categories.AnyAsync(e => e._id == id);
  }
}
