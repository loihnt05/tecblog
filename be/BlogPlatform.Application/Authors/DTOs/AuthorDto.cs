namespace BlogPlatform.Application.Authors.DTOs;

public class AuthorDto
{
    public Guid Id { get; set; }

    public string Username { get; set; } = string.Empty;

    public string Email { get; set; } = string.Empty;

    public string? Bio { get; set; }
    public string? AvatarUrl { get; set; }
}