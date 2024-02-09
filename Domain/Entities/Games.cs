namespace Domain.Entities;

public record Games(int Id, Guid GameId, string GameBoard, int Rows, int Columns, DateTime DateAndTimeCreated);
