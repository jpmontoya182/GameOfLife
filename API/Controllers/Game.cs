using Application.Game.Commands.CreateGame;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API;

[ApiController]
[Route("api/[controller]")]
public class Game: ControllerBase 
{
    private readonly IMediator _mediator;
    public Game(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet("GetNextBoard")]
    public IEnumerable<GameItem> GetNextBoard(int numberOfBoards, Guid idGame)
    {
        throw new NotImplementedException();
    }

    [HttpGet("GetFinalBoard")]
    public IEnumerable<GameItem> GetFinal(Guid boardId)
    {
        throw new NotImplementedException();
    }

    [HttpPost]
    public async Task<CreateGameResponse> Post(CreateGameRequest command)
    {
       return await _mediator.Send(command);
    }

}