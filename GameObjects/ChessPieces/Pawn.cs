using System;
using System.Collections.Generic;
using Chess.Engine.Bases;

namespace Chess.GameObjects.ChessPieces;

public enum PawnDirection
{
    Black = 1,
    White = -1
}

public class Pawn : ChessPiece
{
    private readonly Position _originalPosition;
    private bool HasMoved => Pos != _originalPosition;

    public Pawn(char symbol, ConsoleColor color, int x, int y) : base(symbol, color, x, y)
    {
        _originalPosition = Pos;
    }

    private PawnDirection _direction;
    public void SetPawnDirection(PawnDirection direction)
        => _direction = direction;

    protected override List<Position> CalculateMoves(BaseUIObject[,] boardObjects)
    {
        var list = new List<Position>();

        var posA = new Position(Pos.X, Pos.Y + (int)_direction);
        var posB = new Position(Pos.X, Pos.Y + (int)_direction * 2);

        if (IsPositionInsideBoard(posA) && !IsPositionOccupied(boardObjects, posA))
        {
            list.Add(posA);
        }

        if (!HasMoved && list.Count != 0 && IsPositionInsideBoard(posB) && !IsPositionOccupied(boardObjects, posB))
        {
            list.Add(posB);
        }

        return list;
    }
}
