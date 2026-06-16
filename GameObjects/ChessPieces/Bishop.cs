using System;
using System.Collections.Generic;
using Chess.Engine.Bases;

namespace Chess.Assets.ChessPieces;

public class Bishop(char symbol, ConsoleColor color, int x, int y) : ChessPiece(symbol, color, x, y)
{
    public override ChessPieceColorFactor ColorFactor { get; protected set; }

    public override List<Position> GetAllowedSquares(BaseUIObject[,] objects)
    {
        throw new NotImplementedException();
    }
}
