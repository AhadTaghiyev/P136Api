using ApiIntro.Contexts;
using ApiIntro.Profiles.Categories;
using ApiIntro.Repositories;
using ApiIntro.Repositories.Implementations;
using ApiIntro.Repositories.Interfaces;
using ApiIntro.Services.Implementations;
using ApiIntro.Services.Interfaces;
using ApiIntro.Validations.Categries;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ApiDbContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
});


builder.Services.AddControllers()?.AddFluentValidation(fvc => fvc.RegisterValidatorsFromAssemblyContaining<CategoryPostDtoValidation>());

builder.Services.AddAutoMapper(typeof(CategoryProfile));
builder.Services.AddScoped<ICategoryRepository,CategoryRepository>();
builder.Services.AddScoped<ICategoryService,CategoryService>();

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

