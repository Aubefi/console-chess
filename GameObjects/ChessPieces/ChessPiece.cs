using System;
using System.Collections.Generic;
using Chess.Engine.Bases;

namespace Chess.GameObjects.ChessPieces;

public abstract class ChessPiece(char symbol, ConsoleColor color, int x, int y) : BaseUIObject(symbol, color, x, y)
{
    protected static bool IsPositionInsideBoard(Position pos)
        => pos.X < 8 && pos.X >= 0
        && pos.Y < 8 && pos.Y >= 0;

    public abstract List<Position> GetLegalMoves(BaseUIObject[,] objects);
}
