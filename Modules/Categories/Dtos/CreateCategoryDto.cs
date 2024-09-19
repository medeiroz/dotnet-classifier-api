using ClassifierApi.Modules.Categories.Models;
using MongoDB.Bson;

namespace ClassifierApi.Modules.Categories.Dtos;

public class CreateCategoryDto
{
  public string Name { get; set; }
  public string Description { get; set; }

  public Category ToEntity()
  {
    return new Category
    {
      _id = ObjectId.GenerateNewId(),
      Name = Name,
      Description = Description,
    };
  }
}
