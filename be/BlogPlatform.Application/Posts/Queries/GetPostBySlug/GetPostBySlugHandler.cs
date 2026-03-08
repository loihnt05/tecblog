using BlogPlatform.Application.Interfaces;
using BlogPlatform.Application.Posts.DTOs;
using MediatR;

namespace BlogPlatform.Application.Posts.Queries.GetPostBySlug;

public class GetPostBySlugHandler : IRequestHandler<GetPostBySlugQuery, PostDto?>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetPostBySlugHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<PostDto?> Handle(GetPostBySlugQuery query, CancellationToken cancellationToken)
    {
        var post = await _unitOfWork.Posts.GetBySlugAsync(query.Slug);

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