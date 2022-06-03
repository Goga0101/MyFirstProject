using Microsoft.EntityFrameworkCore;
using MyFirstProject;
using MyFirstProject.Interfaces;
using MyFirstProject.Mapping;
using MyFirstProject.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<IMapper<MyFirstProject.Entities.Category, MyFirstProject.Models.CategoryModel>, CategoryMapper>();


builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IMapper<MyFirstProject.Entities.Product, MyFirstProject.Models.ProductModel>, ProductMapper>();

builder.Services.AddScoped<IPackageService, PackageService>();
builder.Services.AddScoped<IMapper<MyFirstProject.Entities.Package, MyFirstProject.Models.PackageModel>, PackageMapper>();


builder.Services.AddScoped<IPackageProductService, PackageProductService>();
builder.Services.AddScoped<IMapper<MyFirstProject.Entities.PackageProduct, MyFirstProject.Models.PackageProductModel>, PackageProductMapper>();




builder.Services.AddDbContext<MyFirstProjectContext>(x => x.UseSqlServer(builder.Configuration.GetConnectionString("MyFirstProjectDB")));
var app = builder.Build();


using (var scope = app.Services.CreateScope())
{
    using var dbContext = scope.ServiceProvider.GetRequiredService<MyFirstProjectContext>();
    dbContext.Database.Migrate();
}


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



