using System;
using System.Collections.Generic;
using Chess.Engine.Bases;

namespace Chess.GameObjects.ChessPieces;

public abstract class ChessPiece(char symbol, ConsoleColor color, int x, int y) : BaseUIObject(symbol, color, x, y)
{
    protected static bool IsPositionInsideBoard(Position pos)
        => pos.X < 8 && pos.X >= 0
        && pos.Y < 8 && pos.Y >= 0;

    protected static bool IsPositionOccupied(BaseUIObject[,] boardObjects, Position pos)
        => boardObjects[pos.Y, pos.X] is ChessPiece;

    protected bool CanCaptureThisPiece(BaseUIObject[,] boardObjects, Position pos)
        => boardObjects[pos.Y, pos.X] is ChessPiece piece && piece.Color != Color;

    protected abstract List<Position> CalculateMoves(BaseUIObject[,] boardObjects);

    public List<Position> GetLegalMoves(BaseUIObject[,] boardObjects)
        => CalculateMoves(boardObjects);
}
