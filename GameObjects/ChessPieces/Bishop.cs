using System;
using System.Collections.Generic;
using Chess.Engine.Bases;

namespace Chess.GameObjects.ChessPieces;

public class Bishop(char symbol, ConsoleColor color, int x, int y) : ChessPiece(symbol, color, x, y)
{
    public override List<Position> GetLegalMoves(BaseUIObject[,] boardObjects)
    {
        throw new NotImplementedException();
    }
}
