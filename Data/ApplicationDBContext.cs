namespace ClassifierApi.Data;

using ClassifierApi.Modules.Categories.Models;
using Microsoft.EntityFrameworkCore;

public class ApplicationDBContext : DbContext
{
  public ApplicationDBContext(DbContextOptions options) : base(options)
  {

  }

  public DbSet<Category> Categories { get; set; }
}
