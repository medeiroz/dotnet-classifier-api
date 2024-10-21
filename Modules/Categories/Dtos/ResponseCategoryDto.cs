
using ClassifierApi.Modules.Categories.Models;

namespace ClassifierApi.Modules.Categories.Dtos;

public class ResponseCategoryDto
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public static ResponseCategoryDto FromEntity(Category category)
    {
        return new ResponseCategoryDto
        {
            Id = category._id.ToString() ?? "",
            Name = category.Name,
            Description = category.Description,
        };
    }
}


