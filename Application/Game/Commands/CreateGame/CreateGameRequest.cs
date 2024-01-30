using Domain.Entities;
using MediatR;


namespace Application.Game.Commands.CreateGame
{
    public class CreateGameRequest : IRequest<CreateGameResponse>
    {
        public IEnumerable<int[]> Board { get; init; }
    }
}
