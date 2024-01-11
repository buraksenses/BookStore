using BookStore.Data.Context;
using BookStore.Data.Entities;
using BookStore.Data.Repositories.Concretes.Base;
using BookStore.Data.Repositories.Interfaces;

namespace BookStore.Data.Repositories.Concretes;

public class AuthorRepository : GenericRepository<Author,int>,IAuthorRepository
{
    public AuthorRepository(BookStoreDbContext dbContext) : base(dbContext)
    {
    }
}