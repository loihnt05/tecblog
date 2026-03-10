using BlogPlatform.Application.Interfaces;
using BlogPlatform.Domain.Enities;
using MediatR;

namespace BlogPlatform.Application.Authors.Commands.CreateAuthor;

public class CreateAuthorHandler : IRequestHandler<CreateAuthorCommand, Guid>
{
    private readonly IUnitOfWork _unitOfWork;
    public CreateAuthorHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }
    public async Task<Guid> Handle(CreateAuthorCommand command, CancellationToken cancellationToken)
    {
        var author = new User
        {
            Id = Guid.NewGuid(), 
            Username = command.Username, 
            Email = command.Email,
            PasswordHash = BCrypt.Net.BCrypt.HashPassword(command.Password),
            Bio = command.Bio,
            AvatarUrl = command.AvatarUrl,
            CreatedAt = DateTime.UtcNow
        };
        await _unitOfWork.Authors.AddAsync(author);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
        return author.Id;
    }
}