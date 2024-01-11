using BookStore.Data.Entities;
using BookStore.Data.Repositories.Interfaces.Base;

namespace BookStore.Data.Repositories.Interfaces;

public interface IBookRepository : IGenericRepository<Book,int>
{
    
}