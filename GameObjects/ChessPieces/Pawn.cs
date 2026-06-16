using System;
using System.Collections.Generic;
using Chess.Engine.Bases;

namespace Chess.GameObjects.ChessPieces;

public class Pawn(char symbol, ConsoleColor color, int x, int y) : ChessPiece(symbol, color, x, y)
{
    public bool HasMoved { get; set; } = false;

    public override ChessPieceColorFactor ColorFactor { get; protected set; }

    private List<Position> _allowedSquares = [];

    public override List<Position> GetAllowedSquares(BaseUIObject[,] objects)
    {
        _allowedSquares = [];

        TryAddPosition(objects, new Position(Pos.X, Pos.Y + (int)ColorFactor));

        if (!HasMoved)
        {
            TryAddPosition(objects, new Position(Pos.X, Pos.Y + 2 * (int)ColorFactor));
        }

        return _allowedSquares;
    }

    private void TryAddPosition(BaseUIObject[,] objects, Position pos)
    {
        if (objects[pos.Y, pos.X] is not ChessPiece)
        {
            _allowedSquares.Add(pos);
        }
    }
}
