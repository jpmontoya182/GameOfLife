using Application.Game.Commands.CreateGame;
using Application.Game.Commands.GetNextBoard;
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

    [HttpPost("GetNextBoard")]
    public async Task<NextBoardResponse> GetNextBoard(NextBoardRequest request)
    {
        return await _mediator.Send(request);
    }

    [HttpGet("GetFinalBoard")]
    public IEnumerable<GameItem> GetFinal(Guid boardId)
    {
        throw new NotImplementedException();
    }

    [HttpPost]
    public async Task<CreateGameResponse> Post(CreateGameRequest request)
    {
       return await _mediator.Send(request);
    }

}