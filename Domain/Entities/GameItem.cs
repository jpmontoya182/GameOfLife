namespace Domain.Entities;

public record GameItem(IEnumerable<int[]> Board, int NumberOfStates, Guid GameId);
