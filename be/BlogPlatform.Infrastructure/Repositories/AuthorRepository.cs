using BlogPlaform.Application.Interfaces;
using BlogPlatform.Domain.Enities;
using BlogPlatform.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace BlogPlatform.Infrastrcuture.Repositories;

public class AuthorRepository : IAuthorRepository
{
    private readonly BlogDbContext _context;
    public AuthorRepository(BlogDbContext context)
    {
        _context = context;
    }

    public async Task AddAsync(User author)
    {
        await _context.Authors.AddAsync(author);
    }

    public async Task<User?> GetByIdAsync(Guid id)
    {
        return await _context.Authors.FindAsync(id);
    }

    public async Task<User?> GetByEmailAsync(string email)
    {
        return await _context.Authors.FirstOrDefaultAsync(a => a.Email == email);
    }

    public async Task<User?> GetByUsernameAsync(string username)
    {
        return await _context.Authors.FirstOrDefaultAsync(a => a.Username == username);
    }

    public Task UpdateAsync(User author)
    {
        _context.Authors.Update(author);
        return Task.CompletedTask;
    }

    public async Task DeleteAsync(Guid id)
    {
        var author = await GetByIdAsync(id);
        if (author != null)
        {
            _context.Authors.Remove(author);
        }
    }
}