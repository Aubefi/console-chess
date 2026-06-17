using System;
using System.Collections.Generic;
using Chess.Engine.Bases;

namespace Chess.GameObjects.ChessPieces;

public class Bishop(char symbol, ConsoleColor color, int x, int y) : ChessPiece(symbol, color, x, y)
{
    public override List<Position> GetLegalMoves(BaseUIObject[,] boardObjects)
    {
        var bishopMoves = CalculateBishopMoves(boardObjects);

        bishopMoves.RemoveAll(p => !IsPositionInsideBoard(p));

        return bishopMoves;
    }

    private List<Position> CalculateBishopMoves(BaseUIObject[,] boardObjects)
    {
        var list = new List<Position>();

        var a = (x: 1, y: 1);

        for (int k = 0; k < 4; k++)
        {
            var pos = new Position(Pos.X + a.x, Pos.Y + a.y);

            var sumX = a.x;
            var sumY = a.y;

            while (!IsPositionOccupied(boardObjects, pos))
            {
                list.Add(pos);

                sumX += a.x;
                sumY += a.y;

                pos = new(Pos.X + sumX, Pos.Y + sumY);
            }

            (a.x, a.y) = (-a.y, a.x);
        }

        return list;
    }
}
