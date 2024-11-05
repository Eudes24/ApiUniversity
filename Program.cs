using ApiUniversity.Data;
using ApiUniversity.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// The aim of this is to add API controllers to the application
builder.Services.AddControllers()
// Prevent circular references when serializing objects to JSON
    .AddJsonOptions(x =>
        x.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles
    );


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
// You as a developer can use Swagger to interact with the API through a web interface
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<UniversityContext>();

// Add the database context to the application
// This will allow the application to interact with the database
builder.Services.AddDbContext<UniversityContext>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.MapControllers();
app.Run();