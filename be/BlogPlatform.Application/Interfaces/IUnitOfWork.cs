namespace BlogPlatform.Application.Interfaces;

public interface IUnitOfWork : IDisposable
{
    IPostRepository Posts { get; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    Task BeginTransactionAsync();
    Task CommitTransactionAsync();
    Task RollbackTransactionAsync();
}
