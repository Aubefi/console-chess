using System;
using System.Collections.Generic;
using Chess.Engine.Bases;

namespace Chess.GameObjects.ChessPieces;

public class Queen(char symbol, ConsoleColor color, int x, int y) : ChessPiece(symbol, color, x, y)
{
    protected override List<Position> CalculateMoves(BaseUIObject[,] boardObjects)
    {
        var list = new List<Position>();

        var a = (x: 1, y: 0);
        var b = (x: 1, y: 1);

        for (var k = 0; k < 4; k++)
        {
            var posA = new Position(Pos.X + a.x, Pos.Y + a.y);
            var posB = new Position(Pos.X + b.x, Pos.Y + b.y);

            var sumAX = a.x;
            var sumAY = a.y;
            var sumBX = b.x;
            var sumBY = b.y;

            while (IsPositionInsideBoard(posA) && !IsPositionOccupied(boardObjects, posA))
            {
                list.Add(posA);

                sumAX += a.x;
                sumAY += a.y;

                posA = new(Pos.X + sumAX, Pos.Y + sumAY);
            }

            while (IsPositionInsideBoard(posB) && !IsPositionOccupied(boardObjects, posB))
            {
                list.Add(posB);

                sumBX += b.x;
                sumBY += b.y;

                posB = new(Pos.X + sumBX, Pos.Y + sumBY);
            }

            (a.x, a.y) = (-a.y, a.x);
            (b.x, b.y) = (-b.y, b.x);
        }

        return list;
    }
}
