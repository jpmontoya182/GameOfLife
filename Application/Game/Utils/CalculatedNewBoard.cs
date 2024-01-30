using Application.Common.Interfaces;
using Domain.Entities;

namespace Application.Game.Utils;

public class CalculatedNewBoard : ICalculatedNewBoard
{
    public CalculatedNewBoard()
    {
        
    }

    public GameItem ProcessBoard(GameItem game)
    {
        IList<int[]> board = game.Board.ToList();
        IList<int[]> temporalResult = new List<int[]>();

        for (var x = 0; x < board.Count(); x++)
        {
            for (int y = 0; y < board[x].Length; y++)
            {
                Console.WriteLine(board[x][y]);
                // con la posicion hacer la validacion
            }
        }

        // con el resultado de la validacion aplicar filtro

        
        var result  = CreateNewBoard(temporalResult);

        return new GameItem{ Board = result };
    }

    /// <summary>
    /// con las coordenadas, validamos nuestras reglas de negocio y contamos los vivos
    /// necesitamos compartir la matriz entre los procedimientos ?
    /// </summary>
    private void ValidatePositions()
    { 
    
    }


    private IList<int[]> CreateNewBoard(IList<int[]> temporalResult)
    {
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

        return temporalResult;

    }
}