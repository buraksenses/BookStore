using BookStore.Data.Context;
using BookStore.Data.Entities;
using BookStore.Data.Repositories.Concretes.Base;
using BookStore.Data.Repositories.Interfaces;

namespace BookStore.Data.Repositories.Concretes;

public class GenreRepository : GenericRepository<Genre,int>,IGenreRepository
{
    public GenreRepository(BookStoreDbContext dbContext) : base(dbContext)
    {
    }
}