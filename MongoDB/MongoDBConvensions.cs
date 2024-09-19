using MongoDB.Bson.Serialization.Conventions;


namespace ClassifierApi.MongoDB;


public static class MongoConventions
{
  public static void RegisterConventions()
  {
    var conventionPack = new ConventionPack
        {
            new CamelCaseElementNameConvention()
        };
    ConventionRegistry.Register("CamelCase", conventionPack, t => true);
  }
}
