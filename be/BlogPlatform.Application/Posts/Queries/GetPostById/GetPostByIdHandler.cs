using BlogPlatform.Application.Interfaces;
using BlogPlatform.Application.Posts.DTOs;
using MediatR;

namespace BlogPlatform.Application.Posts.Queries.GetPostById;

public class GetPostByIdHandler : IRequestHandler<GetPostByIdQuery, PostDto?>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetPostByIdHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<PostDto?> Handle(GetPostByIdQuery query, CancellationToken cancellationToken)
    {
        var post = await _unitOfWork.Posts.GetByIdAsync(query.Id);

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
