using BlogPlatform.Domain.Enities;

namespace BlogPlatform.Application.Interfaces;

public interface IPostRepository
{
    Task<Post?> GetByIdAsync(Guid id);
    Task<Post?> GetBySlugAsync(string slug);
    Task<List<Post>> GetPublishedPostsAsync();
    Task AddAsync(Post post);
    Task UpdateAsync(Post post);
    Task DeleteAsync(Post post);
}