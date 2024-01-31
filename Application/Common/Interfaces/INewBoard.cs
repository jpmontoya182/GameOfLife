using Application.Game.Commands.CreateGame;
using Domain.Entities;

namespace Application.Common.Interfaces;

public interface INewBoard
{
    public CreateGameResponse CreateNewBoard(IEnumerable<int[]> board);
    public List<Positions> CalculatedNeighbors(int posX, int posY);   
}