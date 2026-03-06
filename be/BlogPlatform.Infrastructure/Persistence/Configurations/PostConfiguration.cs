using BlogPlatform.Domain.Enities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlogPlatform.Infrastructure.Persistence.Configurations;

public class PostConfiguration : IEntityTypeConfiguration<Post>
{
    public void Configure(EntityTypeBuilder<Post> builder)
    {
        builder.ToTable("Posts");

        // Primary Key
        builder.HasKey(p => p.Id);

        // Title
        builder.Property(p => p.Title)
            .IsRequired()
            .HasMaxLength(200);

        // Slug
        builder.Property(p => p.Slug)
            .IsRequired()
            .HasMaxLength(200);

        builder.HasIndex(p => p.Slug)
            .IsUnique();

        // Content
        builder.Property(p => p.Content)
            .IsRequired();

        // Summary
        builder.Property(p => p.Summary)
            .HasMaxLength(500);

        // Publish state
        builder.Property(p => p.IsPublished)
            .IsRequired();

        // Dates
        builder.Property(p => p.PublicationDate)
            .IsRequired();

        builder.Property(p => p.LastModifiedDate)
            .IsRequired();

        // Author relationship
        builder.HasOne(p => p.Author)
            .WithMany(u => u.Posts)
            .HasForeignKey(p => p.AuthorId)
            .OnDelete(DeleteBehavior.Cascade);

        // Comments relationship
        builder.HasMany(p => p.Comments)
            .WithOne()
            .HasForeignKey(c => c.PostId)
            .OnDelete(DeleteBehavior.Cascade);

    }
}