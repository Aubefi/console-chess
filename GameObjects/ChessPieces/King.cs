using System;
using System.Collections.Generic;
using Chess.Engine.Bases;

namespace Chess.GameObjects.ChessPieces;

public class King(char symbol, ConsoleColor color, int x, int y) : ChessPiece(symbol, color, x, y)
{
    protected override List<Position> CalculateMoves(BaseUIObject[,] boardObjects)
    {
        var list = new List<Position>();

        var a = (x: 1, y: 0);
        var b = (x: 1, y: 1);

        for (int k = 0; k < 4; k++)
        {
            (a.x, a.y) = (-a.y, a.x);
            list.Add(new(Pos.X + a.x, Pos.Y + a.y));

            (b.x, b.y) = (-b.y, b.x);
            list.Add(new(Pos.X + b.x, Pos.Y + b.y));
        }

        list.RemoveAll(p => IsPositionOccupied(boardObjects, p));

        return list;
    }
}
