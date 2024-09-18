using ClassifierApi.Models;
using Microsoft.EntityFrameworkCore;

namespace ClassifierApi.Data;

public class ApplicationDBContext : DbContext
{
  public ApplicationDBContext(DbContextOptions options) : base(options)
  {

  }

  public DbSet<Category> Categories { get; set; }
}
