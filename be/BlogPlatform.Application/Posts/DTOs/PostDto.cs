namespace BlogPlatform.Application.Posts.DTOs;

public class PostDto
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Slug { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public string? Summary { get; set; }
    public DateTime PublicationDate { get; set; }
    public string AuthorName { get; set; } = string.Empty;
}