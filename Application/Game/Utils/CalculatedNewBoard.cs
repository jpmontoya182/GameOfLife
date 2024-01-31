using Application.Common.Interfaces;
using Application.Game.Commands.CreateGame;
using Domain.Entities;
using MediatR;

namespace Application.Game.Utils;

public class CalculatedNewBoard : ICalculatedNewBoard
{
    IList<int[]> board = new List<int[]>();
    IList<int[]> temporalResult = new List<int[]>();
    public int totalLenghtX = 0;
    public int totalLenghtY = 0;


    public CreateGameResponse ProcessBoard(IEnumerable<int[]> game)
    {
        board = game.ToList();
        temporalResult = game.ToList();
        totalLenghtX = board.Count();
        totalLenghtY = board[0].Length;        

        for (var x = 0; x < board.Count(); x++)
        {
            for (int y = 0; y < board[x].Length; y++)
            {
                var positions = CalculatedValidPositions(x, y);
                CalculatedValues(positions, x, y);
            }
        }
        
        return new CreateGameResponse { GameId = new Guid(), NewBoard = temporalResult.ToList() };
    }

    public CreateGameResponse ProcessBoard(IEnumerable<int[]> game, int numberOfBoards)
    {
        for (int i = 0; i < numberOfBoards; i++)
        {
           game = ProcessBoard(game).NewBoard;
        }

        return new CreateGameResponse { NewBoard = game.ToList(), GameId = new Guid() };

    }

    public List<Positions> CalculatedValidPositions(int posX, int posY)
    {
        var validPositions =    (from x in Enumerable.Range(posX - 1, 3)
                                from y in Enumerable.Range(posY - 1, 3)
                                where x >= 0 && y >= 0 && x < totalLenghtX && y < totalLenghtY
                                select new Positions { x = x, y = y }).ToList();


        var originalPosition = validPositions.Where(p => p.y == posY && p.x == posX).ToList();
        var result = validPositions.Except(originalPosition).ToList();

        return result;
    }

    private void CalculatedValues(List<Positions> positions, int posX, int posY)
    {
        int liveNeighbors = 0;

        // live cell
        if (board[posX][posY] == 1)
        {
            foreach (var position in positions)
            {
                if (board[position.x][position.y] == 1)
                {
                    liveNeighbors++;
                }   
            }
            // Any live cell with fewer than two live neighbors dies, as if by underpopulation.
            // Any live cell with more than three live neighbors dies, as if by overpopulation.
            if (liveNeighbors < 2 || liveNeighbors > 3)
                temporalResult[posX][posY] = 0;
            // Any live cell with two or three live neighbors lives on to the next generation.
            if (liveNeighbors == 2 || liveNeighbors == 3)
                temporalResult[posX][posY] = 1;
        }
        else // dead cell 
        {
            foreach (var position in positions)
            {
                if (board[position.x][position.y] == 1)
                {
                    liveNeighbors++;
                }
            }
            // Any dead cell with exactly three live neighbors becomes a live cell, as if by reproduction.
            if (liveNeighbors == 3)
                temporalResult[posX][posY] = 1;
        }
    }

}