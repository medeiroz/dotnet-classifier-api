using ClassifierApi.Modules.Categories.Models;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver;

namespace ClassifierApi.Data;

public class ApplicationDBContext : DbContext
{

  public DbSet<Category> Categories { get; set; }

  public static ApplicationDBContext Create(IMongoDatabase database) =>
        new(new DbContextOptionsBuilder<ApplicationDBContext>()
            .UseMongoDB(database.Client, database.DatabaseNamespace.DatabaseName)
            .Options);

  public ApplicationDBContext(DbContextOptions options) : base(options)
  {

  }

  protected override void OnModelCreating(ModelBuilder modelBuilder)
  {
    base.OnModelCreating(modelBuilder);

    modelBuilder.Entity<Category>();
  }
}
