using BlogPlatform.Application.Interfaces;
using BlogPlatform.Application.Posts.DTOs;

namespace BlogPlatform.Application.Posts.Queries.GetPostBySlug;

public class GetPostBySlugHandler
{
    private readonly IPostRepository _repository;

    public GetPostBySlugHandler(IPostRepository repository)
    {
        _repository = repository;
    }

    public async Task<PostDto?> Handle(GetPostBySlugQuery query)
    {
        var post = await _repository.GetBySlugAsync(query.Slug);

        if (post == null)
            return null;

        return new PostDto
        {
            Id = post.Id,
            Title = post.Title,
            Slug = post.Slug,
            Content = post.Content,
            Summary = post.Summary,
            PublicationDate = post.PublicationDate,
            AuthorName = post.Author.Username
        };
    }
}