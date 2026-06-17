using System;
using System.Collections.Generic;
using Chess.Engine.Bases;

namespace Chess.GameObjects.ChessPieces;

public enum PawnDirection
{
    Black = 1,
    White = -1
}

public class Pawn(char symbol, ConsoleColor color, int x, int y) : ChessPiece(symbol, color, x, y)
{
    public bool HasMoved { get; private set; } = false;
    public void MadeFirstMove()
        => HasMoved = true;

    public PawnDirection Direction { get; private set; }
    public void SetPawnDirection(PawnDirection direction)
        => Direction = direction;

    public override List<Position> GetLegalMoves(BaseUIObject[,] boardObjects)
    {
        var pawnMoves = new List<Position>()
        {
            new(Pos.X, Pos.Y + (int)Direction)
        };

        if (!HasMoved)
        {
            pawnMoves.Add(new(Pos.X, Pos.Y + (int)Direction * 2));
        }

        pawnMoves.RemoveAll(p => !IsPositionInsideBoard(p) || boardObjects[p.Y, p.X] is ChessPiece);

        return pawnMoves;
    }
}
