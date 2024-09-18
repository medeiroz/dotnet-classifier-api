namespace ClassifierApi.Modules.Categories.Repositories.Contracts;

using ClassifierApi.Modules.Categories.Models;

public interface ICategoryRepository
{
  Task<IEnumerable<Category>> GetAllAsync();
  Task<Category> GetByIdAsync(int id);
  Task<int> StoreAsync(Category category);
  Task<int> UpdateAsync(Category category);
  Task<int> DeleteAsync(int id);
  Task<bool> ExistsAsync(int? id);
}