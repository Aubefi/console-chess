using System;

namespace Chess.Assets.ChessPieces;

public class Pawn(char symbol, ConsoleColor color, byte x, byte y) : ChessPiece(symbol, color, x, y)
{
    public bool HasMoved { get; set; } = false;
}
