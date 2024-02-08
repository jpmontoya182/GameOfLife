# Game Of Life - Technical test in C# using net7.0 ... still working on the repo/solution

## game description

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

## Architecture
It was built with Clean Architecture

## Patterns
CQRS and Mediator

## Repository
SQL Server

## CI/CD
- GitHub Actions
    Build, Testing, and Docker publication 
- Release a new image in the Docker hub 

## Test
- Unit Test

### Requirements
- you can send a new board state through the API, this will return the new board and an ID of new board
- Gets x number of states away for board, you could send a board ID, and the number of next boards.
- after three equal answers the API response says that the board has no conclusion 
- The boards are stored in a database to support restart/crash/etc... events.
- The code is ready to be in production through a CI/CD pipeline in Git Hub.

### Test API

{
    "board": [[1, 1, 0], [0, 1, 0], [0, 0, 0]]
}


{
  "gameId": "700A501A-7614-4BDB-9907-61B882C58CAB",
  "numberOfBoards": 2
}


## Commands
docker run -it --rm -p 5000:80 --name game jpmontoya182/game-of-life:main
