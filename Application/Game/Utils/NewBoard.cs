using Application.Common.Interfaces;
using Application.Game.Commands.CreateGame;
using Domain.Commands.CreateGame;
using Domain.Entities;

namespace Application.Game.Utils;

public class NewBoard : INewBoard
{
    IList<int[]> board = new List<int[]>();
    IList<int[]> temporalResult = new List<int[]>();
    public int totalLenghtX = 0;
    public int totalLenghtY = 0;

    public CreateGameResponse CreateNewBoard(IEnumerable<int[]> game)
    {
        try
        {
            board = game.ToList();
            temporalResult = game.ToList();
            totalLenghtX = board.Count();
            totalLenghtY = board[0].Length;

            for (var x = 0; x < board.Count(); x++)
            {
                for (int y = 0; y < board[x].Length; y++)
                {
                    var positions = CalculatedNeighbors(x, y);
                    CalculatedValues(positions, x, y);
                }
            }
        }
        catch (Exception error)
        {
            throw error;
        }
 
        return new CreateGameResponse(new Guid(), temporalResult.ToList(), "");
    }
    
    public List<Positions> CalculatedNeighbors(int posX, int posY)
    {
        var validPositions =    (from x in Enumerable.Range(posX - 1, 3)
                                from y in Enumerable.Range(posY - 1, 3)
                                where x >= 0 && y >= 0 && x < totalLenghtX && y < totalLenghtY
                                select new Positions(x, y)).ToList();


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

    public bool ValidateInput(IEnumerable<int[]> game)
    {
        try
        {
            IList<int[]> board = game.ToList();
            int totalY = board[0].Length;
            bool isError = false;

            foreach (var item in board)
            {
                if (item.Length != totalY)
                {
                    isError = true;
                }
            }

            return isError;
        }
        catch (Exception error)
        {
            throw error;
        }

    }

}