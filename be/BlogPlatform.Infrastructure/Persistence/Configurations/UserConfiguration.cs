using BlogPlatform.Domain.Enities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlogPlatform.Infrastructure.Persistence.Configurations;

public class UserConfiguration : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
        builder.ToTable("Authors");

        // Primary key
        builder.HasKey(u => u.Id);

        // Username
        builder.Property(u => u.Username)
            .IsRequired()
            .HasMaxLength(50);

        builder.HasIndex(u => u.Username)
            .IsUnique();

        // Email
        builder.Property(u => u.Email)
            .IsRequired()
            .HasMaxLength(255);

        builder.HasIndex(u => u.Email)
            .IsUnique();

        // Password
        builder.Property(u => u.PasswordHash)
            .IsRequired()
            .HasMaxLength(500);

        // Bio
        builder.Property(u => u.Bio)
            .HasMaxLength(500);

        // Avatar
        builder.Property(u => u.AvatarUrl)
            .HasMaxLength(500);

        // CreatedAt
        builder.Property(u => u.CreatedAt)
            .IsRequired();

        // Relationship: User -> Posts
        builder.HasMany(u => u.Posts)
            .WithOne(p => p.Author)
            .HasForeignKey(p => p.AuthorId)
            .OnDelete(DeleteBehavior.Cascade);

        // Relationship: User -> Comments
        builder.HasMany(u => u.Comments)
            .WithOne()
            .HasForeignKey(c => c.AuthorId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}