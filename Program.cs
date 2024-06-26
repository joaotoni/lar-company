using Microsoft.Extensions.Options; 
using MongoDB.Driver;
using TecnicExam.Services;
using TecnicExam.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.Configure<DatabaseSettings>(
    builder.Configuration.GetSection("DatabaseSettings"));

builder.Services.AddSingleton<IMongoClient>(s =>
    new MongoClient(builder.Configuration.GetConnectionString("MongoDb")));

builder.Services.AddSingleton<IPersonService, PersonService>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        builder =>
        {
            builder.AllowAnyOrigin()
                   .AllowAnyMethod()
                   .AllowAnyHeader();
        });
});

builder.WebHost.UseUrls("http://localhost:3000");

builder.Services.AddControllers();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseCors("AllowAll");

app.UseAuthorization();

app.MapControllers();

app.Run();

public class DatabaseSettings : IDatabaseSettings
{
    public string ConnectionString { get; set; } = string.Empty;
    public string DatabaseName { get; set; } = string.Empty;
}

public interface IDatabaseSettings
{
    string ConnectionString { get; set; }
    string DatabaseName { get; set; }
}
