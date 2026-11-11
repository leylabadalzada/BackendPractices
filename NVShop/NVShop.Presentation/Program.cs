using Microsoft.EntityFrameworkCore;
using NVShop.Data.Contexts;
using NVShop.Data.Repositories.Implements;
using NVShop.Data.Repositories.Interfaces;
using NVShop.Service.Services.implements;
using NVShop.Service.Services.Interfaces;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//IoC container
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Repostories
builder.Services.AddScoped<ICategoryRepository, CatergoryRepository>();

//Services
builder.Services.AddScoped<ICategoryService, CategoryService>();


builder.Services.AddDbContext<AppDbContext>(opt =>
{
    opt.UseNpgsql(builder.Configuration.GetConnectionString("Default"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
