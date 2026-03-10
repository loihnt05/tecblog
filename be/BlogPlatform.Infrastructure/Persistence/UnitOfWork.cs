using BlogPlaform.Application.Interfaces;
using BlogPlatform.Application.Interfaces;
using BlogPlatform.Infrastrcuture.Repositories;
using BlogPlatform.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore.Storage;

namespace BlogPlatform.Infrastructure.Persistence;

public class UnitOfWork : IUnitOfWork
{
    private readonly BlogDbContext _context;
    private IDbContextTransaction? _transaction;
    private IPostRepository? _postRepository;
    private IAuthorRepository? _authorRepository;

    public UnitOfWork(BlogDbContext context)
    {
        _context = context;
    }

    public IPostRepository Posts => _postRepository ??= new PostRepository(_context);
    public IAuthorRepository Authors => _authorRepository ??= new AuthorRepository(_context);

    public async Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        return await _context.SaveChangesAsync(cancellationToken);
    }

    public async Task BeginTransactionAsync()
    {
        _transaction = await _context.Database.BeginTransactionAsync();
    }

    public async Task CommitTransactionAsync()
    {
        if (_transaction != null)
        {
            await _transaction.CommitAsync();
            await _transaction.DisposeAsync();
            _transaction = null;
        }
    }

    public async Task RollbackTransactionAsync()
    {
        if (_transaction != null)
        {
            await _transaction.RollbackAsync();
            await _transaction.DisposeAsync();
            _transaction = null;
        }
    }

    public void Dispose()
    {
        _transaction?.Dispose();
        _context.Dispose();
    }
}
