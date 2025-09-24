using Microsoft.EntityFrameworkCore.Storage;

namespace Movies.Infrastructure.Database;

public class UnitOfWork(AppDbContext appDbContext) : IUnitOfWork
{
    private IDbContextTransaction _transaction;
    
    public async Task BeginTransactionAsync()
    {
        _transaction = await appDbContext.Database.BeginTransactionAsync();
    }

    public async Task CommitAsync()
    {
        await appDbContext.SaveChangesAsync();
        await _transaction?.CommitAsync()!;
    }

    public async Task RollbackAsync()
    {
        await _transaction?.RollbackAsync()!;
    }

    public async Task SaveChangesAsync()
    {
        await appDbContext.SaveChangesAsync();
    }
    
    public void Dispose()
    {
        _transaction?.Dispose();
        appDbContext.Dispose();
    }
}