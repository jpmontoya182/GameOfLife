using Application.Game.Commands.CreateGame;
using Application.Game.Utils;
using Domain.Entities;

namespace Application.Common.Interfaces;

public interface ICalculatedNewBoard{
    public CreateGameResponse ProcessBoard(IEnumerable<int[]> board);
    public CreateGameResponse ProcessBoard(IEnumerable<int[]> board, int numberOfBoards);
    public List<Positions> CalculatedValidPositions(int posX, int posY);   
}