using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ClassifierApi.Modules.Categories.Models;

public class Category
{
  [BsonId]
  public ObjectId? _id { get; set; } = null;
  public string Name { get; set; }
  public string Description { get; set; }
}
