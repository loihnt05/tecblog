using BlogPlatform.Application.Posts.DTOs;
using MediatR;

namespace BlogPlatform.Application.Posts.Queries.GetPostBySlug;

public record GetPostBySlugQuery(string Slug) : IRequest<PostDto?>;