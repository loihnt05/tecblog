using BlogPlatform.Application.Authors.DTOs;
using BlogPlatform.Application.Interfaces;
using MediatR;

namespace BlogPlatform.Application.Authors.Queries.GetAuthors;

public class GetAuthorsHandler : IRequestHandler<GetAuthorsQuery, List<AuthorDto>>
{
    private readonly IUnitOfWork _unitOfWork;
    public GetAuthorsHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public async Task<List<AuthorDto>> Handle(GetAuthorsQuery request, CancellationToken cancellationToken)
    {
        var authors = await _unitOfWork.Authors.GetAllAsync();
        return authors.Select(a => new AuthorDto
        {
            Id = a.Id,
            Username = a.Username,
            Email = a.Email,
            Bio = a.Bio
        }).ToList();
    }
    
}