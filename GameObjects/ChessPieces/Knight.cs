using System;
using System.Collections.Generic;
using Chess.Engine.Bases;

namespace Chess.GameObjects.ChessPieces;

public class Knight(char symbol, ConsoleColor color, int x, int y) : ChessPiece(symbol, color, x, y)
{
    public override List<Position> GetLegalMoves(BaseUIObject[,] boardObjects)
    {
        var knightMoves = CalculateKnightMoves(boardObjects);

        knightMoves.RemoveAll(p => !IsPositionInsideBoard(p));

        return knightMoves;
    }

    private List<Position> CalculateKnightMoves(BaseUIObject[,] boardObjects)
    {
        var list = new List<Position>();

        var a = (x: 1, y: 2);
        var b = (x: 2, y: 1);

        for (int k = 0; k < 4; k++)
        {
            (a.x, a.y) = (-a.y, a.x);
            list.Add(new(Pos.X + a.x, Pos.Y + a.y));

            (b.x, b.y) = (-b.y, b.x);
            list.Add(new(Pos.X + b.x, Pos.Y + b.y));
        }

        return list;
    }
}
