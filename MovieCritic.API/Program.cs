using Microsoft.EntityFrameworkCore;
using MovieCritic.Core.Services;
using MovieCritic.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


// And here is connection to Database with the usage of connection string
// As a Sql server I used PostgreSQL as it is comfortable for creating small projects
builder.Services.AddDbContext<ApplicationDbContext>(optionsAction =>
optionsAction.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// Again here I used dependency injection and made IGptService on the implementaion of GptSerivce
// also this means that a new instance of the specified service is created and shared within each individual request to the application. 
builder.Services.AddScoped<IGptService, GptService>();


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
