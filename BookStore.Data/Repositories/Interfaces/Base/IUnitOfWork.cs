namespace BookStore.Data.Repositories.Interfaces.Base;

public interface IUnitOfWork
{
    Task SaveChangesAsync();

    Task BeginTransactionAsync();

    Task TransactionCommitAsync();
}