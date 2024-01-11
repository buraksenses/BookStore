using BookStore.Data.Context;
using BookStore.Data.Repositories.Interfaces.Base;
using Microsoft.EntityFrameworkCore.Storage;

namespace BookStore.Data.Repositories.Concretes.Base;

public class UnitOfWork : IUnitOfWork
{
    private readonly BookStoreDbContext _dbContext;
    private IDbContextTransaction _transaction;
    private readonly bool isInMemory;

    public UnitOfWork(BookStoreDbContext dbContext, bool isInMemory)
    {
        _dbContext = dbContext;
        this.isInMemory = isInMemory;
    }

    public async Task SaveChangesAsync()
    {
        await _dbContext.SaveChangesAsync();
    }

    public async Task BeginTransactionAsync()
    {
        if(isInMemory)
            return;
        _transaction = await _dbContext.Database.BeginTransactionAsync();
    }

    public async Task TransactionCommitAsync()
    {
        if (isInMemory)
        {
            await SaveChangesAsync();
            return;
        }
        if (_transaction == null)
            throw new InvalidOperationException("transaction has not been started!");

        try
        {
            await SaveChangesAsync();

            await _transaction.CommitAsync();
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw;
        }
        finally
        {
            await _transaction.DisposeAsync();
        }
        
    }
}