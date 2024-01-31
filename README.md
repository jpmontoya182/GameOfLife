# Game Of life 
The universe of the Game of Life is an infinite, two-dimensional orthogonal grid of square cells, 
each of which is in one of two possible states, live or dead (or populated and unpopulated, respectively). 
Every cell interacts with its eight neighbors, which are the cells that are horizontally, vertically, or diagonally adjacent. 
At each step in time, the following transitions occur:

Any live cell with fewer than two live neighbors dies, as if by underpopulation.
Any live cell with two or three live neighbors lives on to the next generation.
Any live cell with more than three live neighbors dies, as if by overpopulation.
Any dead cell with exactly three live neighbors becomes a live cell, as if by reproduction.

The initial pattern constitutes the seed of the system. The first generation is created by applying the above rules simultaneously 
to every cell in the seed, live or dead; births and deaths occur simultaneously, and the discrete moment at which this 
happens is sometimes called a tick.[nb 1] Each generation is a pure function of the preceding one. 
The rules continue to be applied repeatedly to create further generations.

https://en.wikipedia.org/wiki/Conway%27s_Game_of_Life

## Architecture
Clean Architecture

## Patterns
CQRS and Mediator

## Repository
SQL 

## CI/CD
- Unit Test 
- Release a new image in docker hub 

## Test
- Unit Test

### Requirements

The API should have implementations for at least the following:
1.Allows uploading a new board state, returns id of board
2.Get next state for board, returns next state
3.Gets x number of states away for board
4. Gets final state for board. If board doesn't go to conclusion after x number of attempts, returns error

The service you write should be able to restart/crash/etc... but retain the state of the boards.

The code you write should be production ready.

### Test API

{
    "board": [[1, 1, 0], [0, 1, 0], [0, 0, 0]]
}


{
  "gameId": "700A501A-7614-4BDB-9907-61B882C58CAB",
  "numberOfBoards": 2
}


## Commands
docker run -d jpmontoya182/game-of-life:main --name game-of-life -p 8999:80