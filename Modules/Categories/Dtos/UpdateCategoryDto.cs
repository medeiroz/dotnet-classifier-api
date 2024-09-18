using ClassifierApi.Modules.Categories.Models;

namespace ClassifierApi.Modules.Categories.Dtos;

public class UpdateCategoryDto
{
  public string Name { get; set; }
  public string Description { get; set; }

  public Category ToEntity()
  {
    return new Category
    {
      Name = Name,
      Description = Description,
    };
  }
}
