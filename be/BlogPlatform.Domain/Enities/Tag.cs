namespace BlogPlatform.Domain.Enities;

public class Tag
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Slug { get; set; } = string.Empty;    
    public ICollection<PostTag> PostTags { get; set; } = new List<PostTag>();
}