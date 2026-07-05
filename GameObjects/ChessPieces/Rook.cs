using System;
using System.Collections.Generic;
using Chess.Engine.Bases;

namespace Chess.GameObjects.ChessPieces;

public class Rook(char symbol, ConsoleColor color, int x, int y) : ChessPiece(symbol, color, x, y)
{
    protected override List<Position> CalculateMoves(BaseUIObject[,] boardObjects)
    {
        var list = new List<Position>();

        var a = (x: 1, y: 0);

        for (var k = 0; k < 4; k++)
        {
            var pos = new Position(Pos.X + a.x, Pos.Y + a.y);

            var sumX = a.x;
            var sumY = a.y;

            while (IsPositionInsideBoard(pos) && !IsPositionOccupied(boardObjects, pos))
            {
                list.Add(pos);

                sumX += a.x;
                sumY += a.y;

                pos = new(Pos.X + sumX, Pos.Y + sumY);
            }
            if (IsPositionInsideBoard(pos) && CanCaptureThisPiece(boardObjects, pos))
            {
                list.Add(pos);
            }

            (a.x, a.y) = (-a.y, a.x);
        }

        return list;
    }
}
