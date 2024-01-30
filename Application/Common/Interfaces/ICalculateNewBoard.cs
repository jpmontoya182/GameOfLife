using Application.Game.Commands.CreateGame;
using Domain.Entities;

namespace Application.Common.Interfaces;

public interface ICalculatedNewBoard{
    public CreateGameResponse ProcessBoard(IEnumerable<int[]> board);
}