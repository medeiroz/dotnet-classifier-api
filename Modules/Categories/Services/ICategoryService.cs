using ClassifierApi.Modules.Categories.Dtos;
using ClassifierApi.Modules.Categories.Models;

namespace ClassifierApi.Modules.Categories.Services;

public interface ICategoryService
{
  Task<IEnumerable<Category>> GetAll();
  Task<Category> GetById(string Id);
  Task<Category> Create(CreateCategoryDto Dto);
  Task<Category> Update(string Id, UpdateCategoryDto Dto);
  Task<int> Delete(string Id);
}