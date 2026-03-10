using BlogPlatform.Application.Interfaces;
using BlogPlatform.Domain.Enities;
using BlogPlatform.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace BlogPlatform.Infrastructure.Repositories;

public class PostRepository : IPostRepository
{
    private readonly BlogDbContext _context;

    public PostRepository(BlogDbContext context)
    {
        _context = context;
    }

    public async Task<Post?> GetBySlugAsync(string slug)
    {
        return await _context.Posts
            .Include(p => p.Author)
            .FirstOrDefaultAsync(p => p.Slug == slug);
    }

    public async Task AddAsync(Post post)
    {
        await _context.Posts.AddAsync(post);
    }

    public async Task<Post?> GetByIdAsync(Guid id)
    {
        return await _context.Posts
            .Include(p => p.Author)
            .FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<List<Post>> GetPublishedPostsAsync()
    {
        return await _context.Posts
            .Include(p => p.Author)
            .Where(p => p.IsPublished)
            .OrderByDescending(p => p.PublicationDate)
            .ToListAsync();
    }

    public Task UpdateAsync(Post post)
    {
        _context.Posts.Update(post);
        return Task.CompletedTask;
    }

    public Task DeleteAsync(Post post)
    {
        _context.Posts.Remove(post);
        return Task.CompletedTask;
    }
    public async Task<List<Post>> GetPostsAsync()
    {
        return await _context.Posts.ToListAsync();
    }
}