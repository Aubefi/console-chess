using System;
using System.Collections.Generic;
using Chess.Engine.Bases;

namespace Chess.GameObjects.ChessPieces;

public abstract class ChessPiece(char symbol, ConsoleColor color, int x, int y) : BaseUIObject(symbol, color, x, y)
{

    public abstract List<Position> GetAllowedSquares(BaseUIObject[,] objects);
}
