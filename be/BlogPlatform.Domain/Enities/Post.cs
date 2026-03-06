using System.Formats.Asn1;

namespace BlogPlatform.Domain.Enities;

public class Post
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Slug { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public string? Summary { get; set; }
    public bool IsPublished { get; set; }
    public DateTime LastModifiedDate { get; set; }  
    public DateTime PublicationDate { get; set; }
    public Guid AuthorId { get; set; }
    public User Author { get; set; } = null!;
    public ICollection<PostTag> Tags { get; set; } = new List<PostTag>();
    public ICollection<Comment> Comments { get; set; } = new List<Comment>();
}