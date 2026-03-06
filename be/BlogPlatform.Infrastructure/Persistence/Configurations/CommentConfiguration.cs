using BlogPlatform.Domain.Enities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BlogPlatform.Infrastructure.Persistence.Configurations;

public class CommentConfiguration : IEntityTypeConfiguration<Comment>
{
    public void Configure(EntityTypeBuilder<Comment> builder)
    {
        builder.ToTable("Comments");

        builder.HasKey(x => x.Id);
        builder.Property(x => x.Content)
            .IsRequired()
            .HasMaxLength(1000);
        builder.Property(x => x.PublicationDate)
            .IsRequired();
        builder.Property(x => x.PostId)
            .IsRequired();
        builder.Property(x => x.AuthorId)
            .IsRequired();
    }
}