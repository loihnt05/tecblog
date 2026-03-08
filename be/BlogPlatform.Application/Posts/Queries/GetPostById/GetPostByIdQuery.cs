using BlogPlatform.Application.Posts.DTOs;
using MediatR;

namespace BlogPlatform.Application.Posts.Queries.GetPostById;

public record GetPostByIdQuery(Guid Id) : IRequest<PostDto?>;
