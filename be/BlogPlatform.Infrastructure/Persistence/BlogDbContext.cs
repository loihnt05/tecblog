using BlogPlatform.Domain.Enities;
using Microsoft.EntityFrameworkCore;

namespace BlogPlatform.Infrastructure.Persistence;

public class BlogDbContext : DbContext
{
    public BlogDbContext(DbContextOptions<BlogDbContext> options) : base(options)
    {
    }
    public DbSet<Post> Posts => Set<Post>();
    public DbSet<Comment> Comments => Set<Comment>();
    public DbSet<User> Authors => Set<User>();
    public DbSet<Tag> Tags => Set<Tag>();
    public DbSet<PostTag> PostTags => Set<PostTag>();
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(BlogDbContext).Assembly);
        
        // Seed test data
        modelBuilder.Entity<User>().HasData(
            new User
            {
                Id = Guid.Parse("11111111-1111-1111-1111-111111111111"),
                Username = "testuser",
                Email = "test@example.com",
                PasswordHash = "hash", // In production, use proper password hashing
                Bio = "Test user for development",
                AvatarUrl = null,
                CreatedAt = new DateTime(2026, 1, 1, 0, 0, 0, DateTimeKind.Utc)
            }
        );
        modelBuilder.Entity<Post>().HasData(
            new Post
            {
                Id = Guid.Parse("00000000-0000-0000-0000-000000000000"),
                Title = "Test Post",
                Slug = "test-post",
                Content = "This is a test post for development.",
                PublicationDate = new DateTime(2026, 1, 1, 0, 0, 0, DateTimeKind.Utc),
                IsPublished = true,
                AuthorId = Guid.Parse("11111111-1111-1111-1111-111111111111")
            }
        );
    }
}