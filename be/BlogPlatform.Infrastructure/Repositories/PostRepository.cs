using BlogPlatform.Application.Interfaces;
using BlogPlatform.Domain.Enities;
using BlogPlatform.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

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
        await _context.SaveChangesAsync();
    }

    public Task<Post?> GetByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<List<Post>> GetPublishedPostsAsync()
    {
        throw new NotImplementedException();
    }

    public Task UpdateAsync(Post post)
    {
        throw new NotImplementedException();
    }

    public Task DeleteAsync(Post post)
    {
        throw new NotImplementedException();
    }
}