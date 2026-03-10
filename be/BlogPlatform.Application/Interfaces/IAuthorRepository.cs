using BlogPlatform.Domain.Enities;

namespace BlogPlaform.Application.Interfaces;

public interface IAuthorRepository
{
    Task<User?> GetByIdAsync(Guid id);
    Task<User?> GetByUsernameAsync(string username);
    Task<User?> GetByEmailAsync(string email);
    Task AddAsync(User author);
    Task UpdateAsync(User author);
    Task DeleteAsync(Guid id);
    Task<List<User>> GetAllAsync();
}