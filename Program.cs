using Microsoft.EntityFrameworkCore;
using ClassifierApi.Data;
using ClassifierApi.Modules.Categories.Repositories;
using ClassifierApi.MongoDB;
using ClassifierApi.Modules.Categories.Services;

var builder = WebApplication.CreateBuilder(args);

MongoConventions.RegisterConventions();

var mongoDBSettings = builder.Configuration.GetSection("MongoDBSettings").Get<MongoDBSettings>();
builder.Services.Configure<MongoDBSettings>(builder.Configuration.GetSection("MongoDBSettings"));

if (mongoDBSettings is null)
{
  throw new Exception("MongoDBSettings not found in configuration");
}

builder.Services.AddDbContext<ApplicationDBContext>(options =>
options.UseMongoDB(mongoDBSettings.URI ?? "", mongoDBSettings.DatabaseName ?? ""));



// Add services to the container.
builder.Services.AddControllers();

// Register repositories
builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();

// Register services
builder.Services.AddScoped<ICategoryService, CategoryService>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
  app.UseSwagger();
  app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
