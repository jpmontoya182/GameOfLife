using Application.Common.Interfaces;
using Application.Game.Commands.CreateGame;
using Application.Game.Commands.GetNextBoard;
using Domain.Entities;
using Infrastructure.Models;
using Infrastructure.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.RepositoryOperations
{
    public class NextBoardDbContext : INextBoardDbContext
    {
        private readonly ApplicationDbContext _applicationDbContext;

        public NextBoardDbContext(ApplicationDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public List<int[]> GetBoard(Guid GameId)
        {
            var id = Guid.Parse(GameId.ToString().ToUpper());
            try
            {
                var query = _applicationDbContext.Games.Single(b => b.GameId == id);
                var cols = query.Columns;
                var rows = query.Rows;
                var Board = query.GameBoard.ToCharArray();
                List<int[]> board = new List<int[]>();
                List<int> board2 = new List<int>();
                int eval = 1;
               
                for (int i = 0; i < Board.Length; i++)
                {
                    board2.Add((int)Char.GetNumericValue(Board[i]));
                    eval = i + 1;
                    if (eval % cols == 0)
                    {
                        board.Add(board2.ToArray());
                        board2.Clear();
                    }
                }
                return board;                            
            }
            catch (Exception error)
            {
                Console.WriteLine(error);
                return new List<int[]> { };
            }
        }

        public NextBoardResponse UpdateBoard(Guid GameId, List<int[]> Board)
        {
            List<int[]> newBoard = Board.ToList();
            int totalLenghtY = newBoard[0].Length;
            int totalLenghtX = Board.Count();
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

                var record = new Game
                {
                    GameBoard = sb.ToString(),
                    GameId = GameId,
                    DateAndTimeCreated = DateTime.Now,
                    Rows = totalLenghtX,
                    Columns = totalLenghtY
                };
                _applicationDbContext.Games.Add(record);
                _applicationDbContext.SaveChanges();

                return new NextBoardResponse { GameId = record.GameId, NewBoard = newBoard };
            }
            catch(Exception error) 
            {
                Console.WriteLine(error);
                return new NextBoardResponse() { };       
            }

        }
    }
}
