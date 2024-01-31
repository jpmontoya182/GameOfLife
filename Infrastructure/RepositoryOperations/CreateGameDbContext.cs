using Application.Common.Interfaces;
using Application.Game.Commands.CreateGame;
using Domain.Entities;
using Infrastructure.Models;
using Infrastructure.Repository;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;
using System.Text;

namespace Infrastructure.RepositoryOperations
{
    public class CreateGameDbContext : ICreateGameDbContext
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public CreateGameDbContext(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;   
        }

        public CreateGameResponse SaveBoard(CreateGameResponse board)
        {
            var GameId = Guid.NewGuid();
            List<int[]> newBoard = board.NewBoard.ToList();
            int totalLenghtY = newBoard[0].Length;
            int totalLenghtX = board.NewBoard.Count();
            var sb = new StringBuilder();

            try
            {
                for (var x = 0; x < newBoard.Count(); x++)
                {
                    for (int y = 0; y < newBoard[x].Length; y++)
                    {
                        sb.Append(newBoard[x][y].ToString());
                    }                      
                }                
       
                var record = new Game { 
                    GameBoard = sb.ToString(), 
                    GameId = GameId, 
                    DateAndTimeCreated = DateTime.Now,
                    Rows = totalLenghtX,
                    Columns = totalLenghtY                
                };
                _applicationDbContext.Games.Add(record);
                _applicationDbContext.SaveChanges();

                return new CreateGameResponse { GameId = record.GameId, NewBoard = newBoard };
                }
            catch (Exception error)
            {
                Console.WriteLine(error);
                return new CreateGameResponse();
            }
        }
    }
}
