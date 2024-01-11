using BookStore.Data.Context;
using BookStore.Data.Entities;
using BookStore.Data.Repositories.Concretes.Base;
using BookStore.Data.Repositories.Interfaces;

namespace BookStore.Data.Repositories.Concretes;

public class BookRepository : GenericRepository<Book,int>,IBookRepository
{
    public BookRepository(BookStoreDbContext dbContext) : base(dbContext)
    {
    }
}