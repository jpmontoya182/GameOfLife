using Application.Common.Interfaces;
using Application.Game.Commands.CreateGame;
using Domain.Entities;
using System.Collections.Generic;

namespace Application.Game.Utils;

class Positions
{
    public int x { get; set; }
    public int y { get; set; }
}

public class CalculatedNewBoard : ICalculatedNewBoard
{
    IList<int[]> board = new List<int[]>();
    IList<int[]> temporalResult = new List<int[]>();
    int totalLenghtX = 0;
    int totalLenghtY = 0;


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
        
        var result  = CreateNewBoard(temporalResult);

        return new CreateGameResponse { GameId = result.GameId, NewBoard = result.NewBoard };
    }

    /// <summary>
    /// con las coordenadas, validamos nuestras reglas de negocio y contamos los vivos
    /// necesitamos compartir la matriz entre los procedimientos ?
    /// </summary>
    private List<Positions> CalculatedValidPositions(int posX, int posY)
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
        foreach (var position in positions)
        {  
            if (board[position.x][position.y] == 1)
            {
                liveNeighbors++;
            }
            
        }    
        temporalResult[posX][posY] = liveNeighbors;
    }


    private CreateGameResponse CreateNewBoard(IList<int[]> temporalResult)
    {
        if (temporalResult.Count() == 0) return null;
   
        for (var x = 0; x < temporalResult.Count(); x++)
        {
            for (int y = 0; y < temporalResult[x].Length; y++)
            {

                if (temporalResult[x][y] > 2)
                {
                    temporalResult[x][y] = 1;
                }
                else
                {
                    temporalResult[x][y] = 0;
                }
            }
        }

        return new CreateGameResponse { NewBoard = temporalResult.ToList(), GameId = new Guid() };
    }
}