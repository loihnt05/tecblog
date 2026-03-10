using BlogPlatform.Application.Authors.DTOs;
using BlogPlatform.Application.Interfaces;
using MediatR;

namespace BlogPlatform.Application.Authors.Queries.GetAuthorById;

public class GetAuthorByIdHandler : IRequestHandler<GetAuthorByIdQuery, AuthorDto?>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetAuthorByIdHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<AuthorDto?> Handle(GetAuthorByIdQuery query, CancellationToken cancellationToken)
    {
        var author = await _unitOfWork.Authors.GetByIdAsync(query.Id);

        if (author == null)
            return null;

        return new AuthorDto
        {
            Id = author.Id,
            Username = author.Username,
            Email = author.Email,
            Bio = author.Bio,
            AvatarUrl = author.AvatarUrl
        };
    }
}