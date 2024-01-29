using Application.Game.Commands.CreateGame;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API;

public class Game: ControllerBase 
{
    private readonly ILogger<Game> _logger;
    public Game(ILogger<Game> logger)
    {
         _logger = logger;
    }

   //  [HttpGet()]
   //  public IEnumerable<WeatherForecast> GetNextBoard(int numberOfBoards)
   //  {
   //     throw new NotImplementedException();
   //  }

   //  [HttpGet(Name = "GetWeatherForecast")]
   //  public IEnumerable<WeatherForecast> GetFinal(Guid boardId)
   //  {
   //     throw new NotImplementedException();
   //  }

    [HttpPost]
    public async Task<GameItem> Post(ISender sender, CreateGameCommand command)
    {
       return await sender.Send(command);
    }

}