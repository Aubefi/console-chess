using System;
using System.Collections.Generic;
using Chess.Engine.Bases;

namespace Chess.Assets.ChessPieces;

public enum ChessPieceColorFactor
{
    Black = 1,
    White = -1
}

public abstract class ChessPiece(char symbol, ConsoleColor color, int x, int y) : BaseUIObject(symbol, color, x, y)
{
    public abstract ChessPieceColorFactor ColorFactor { get; protected set; }
    public virtual void SetColorFactor(ChessPieceColorFactor colorFactor)
        => ColorFactor = colorFactor;

    public abstract List<Position> GetAllowedSquares(BaseUIObject[,] objects);
}
