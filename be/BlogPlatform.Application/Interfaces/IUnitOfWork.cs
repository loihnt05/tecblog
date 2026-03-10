using BlogPlaform.Application.Interfaces;

namespace BlogPlatform.Application.Interfaces;

public interface IUnitOfWork : IDisposable
{
    IPostRepository Posts { get; }
    IAuthorRepository Authors { get; }
    Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    Task BeginTransactionAsync();
    Task CommitTransactionAsync();
    Task RollbackTransactionAsync();
}
