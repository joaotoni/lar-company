using TecnicExam.Services; // Adicione esta linha para importar os namespaces dos serviços

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddSingleton<IProductService, ProductService>();
builder.Services.AddSingleton<ICategoryService, CategoryService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
