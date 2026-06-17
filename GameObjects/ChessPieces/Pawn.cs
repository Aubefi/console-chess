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

    public PawnDirection Direction { get; private set; }
    public void SetPawnDirection(PawnDirection direction)
        => Direction = direction;

    protected override List<Position> CalculateMoves(BaseUIObject[,] boardObjects)
    {
        var list = new List<Position>
        {
            new(Pos.X, Pos.Y + (int)Direction)
        };

        if (!HasMoved)
        {
            list.Add(new(Pos.X, Pos.Y + (int)Direction * 2));
        }

        list.RemoveAll(p => !IsPositionInsideBoard(p) || IsPositionOccupied(boardObjects, p));

        return list;
    }
}
