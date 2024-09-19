using ClassifierApi.Modules.Categories.Models;
using MongoDB.Bson;

namespace ClassifierApi.Modules.Categories.Repositories;

public interface ICategoryRepository
{
  Task<IEnumerable<Category>> GetAllAsync();
  Task<Category> GetByIdAsync(ObjectId id);
  Task<int> StoreAsync(Category category);
  Task<int> UpdateAsync(Category category);
  Task<int> DeleteAsync(ObjectId id);
  Task<bool> ExistsAsync(ObjectId? id);
}