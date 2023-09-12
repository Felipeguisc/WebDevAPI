using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Aula_API.DataAccess;

var builder = WebApplication.CreateBuilder(args);

var configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json")
    .Build();

var dbContextOptions = new DbContextOptionsBuilder<MyDbContext>()
    .UseSqlite(configuration.GetConnectionString("MyDbConnection"))
    .Options;

// Add services to the container.
var dbContext = new MyDbContext(dbContextOptions);

builder.Services.AddDbContext<MyDbContext>(options =>
{
    options.UseSqlite(configuration.GetConnectionString("MyDbConnection"));
});

builder.Services.AddControllers();
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

