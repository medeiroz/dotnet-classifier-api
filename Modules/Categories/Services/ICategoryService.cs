using ClassifierApi.Modules.Categories.Dtos;
using ClassifierApi.Modules.Categories.Models;

namespace ClassifierApi.Modules.Categories.Services;

public interface ICategoryService
{
  Task<IEnumerable<Category>> GetAll();
  Task<Category> GetById(string id);
  Task<Category> Create(CreateCategoryDto createCategoryDto);
  Task<Category> Update(string id, UpdateCategoryDto updateCategoryDto);
  Task<int> Delete(string id);
}