using MediatR;

namespace Domain.Commands.CreateGame;

public record CreateGameRequest : IRequest<CreateGameResponse>
{
    public IEnumerable<int[]> Board { get; set; } = null!;
}
