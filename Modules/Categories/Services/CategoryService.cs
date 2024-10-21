using ClassifierApi.Modules.Categories.Dtos;
using ClassifierApi.Modules.Categories.Models;
using ClassifierApi.Modules.Categories.Repositories;
using MongoDB.Bson;

namespace ClassifierApi.Modules.Categories.Services;

public class CategoryService(ICategoryRepository repository) : ICategoryService
{
  private readonly ICategoryRepository _repository = repository;

  public async Task<IEnumerable<Category>> GetAll()
  {
    return await _repository.GetAllAsync();
  }

  public async Task<Category> GetById(string id)
  {
    return await _repository.GetByIdAsync(new ObjectId(id));
  }

  public async Task<Category> Create(CreateCategoryDto createCategoryDto)
  {
    var entity = createCategoryDto.ToEntity();
    await _repository.StoreAsync(entity);
    return entity;
  }

  public async Task<Category> Update(string id, UpdateCategoryDto updateCategoryDto)
  {
    var entity = updateCategoryDto.ToEntity();
    entity._id = new ObjectId(id);
    await _repository.UpdateAsync(entity);
    return entity;
  }

  public async Task<int> Delete(string id)
  {
    return await _repository.DeleteAsync(new ObjectId(id));
  }
}