using BookStore.Business.Mappings;
using BookStore.Business.Services.Concretes;
using BookStore.Business.Services.Interfaces;
using BookStore.Business.Validators;
using BookStore.Data.Context;
using BookStore.Data.Repositories.Concretes;
using BookStore.Data.Repositories.Concretes.Base;
using BookStore.Data.Repositories.Interfaces;
using BookStore.Data.Repositories.Interfaces.Base;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<BookStoreDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("BookStoreConnectionString")));

builder.Services.AddAutoMapper(typeof(MappingProfiles));

builder.Services.AddScoped<IUnitOfWork, UnitOfWork>(serviceProvider =>
{
    var dbContext = serviceProvider.GetRequiredService<BookStoreDbContext>();
    var isInMemory = dbContext.Database.ProviderName == "Microsoft.EntityFrameworkCore.InMemory";
    return new UnitOfWork(dbContext, isInMemory);
});

builder.Services.AddFluentValidation(fv => 
    fv.RegisterValidatorsFromAssemblyContaining<CreateBookValidator>());

builder.Services.AddScoped<IAuthorRepository, AuthorRepository>();
builder.Services.AddScoped<IAuthorService, AuthorService>();

builder.Services.AddScoped<IBookRepository, BookRepository>();
builder.Services.AddScoped<IBookService, BookService>();

builder.Services.AddScoped<IGenreRepository, GenreRepository>();
builder.Services.AddScoped<IGenreService, GenreService>();


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