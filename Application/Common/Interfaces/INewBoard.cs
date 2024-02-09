using Domain.Commands.CreateGame;
using Domain.Entities;

namespace Application.Common.Interfaces;

public interface INewBoard
{
    CreateGameResponse CreateNewBoard(IEnumerable<int[]> board);
    List<Positions> CalculatedNeighbors(int posX, int posY);
    bool ValidateInput(IEnumerable<int[]> game);
}