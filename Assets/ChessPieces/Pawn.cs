using System;
using Chess.Engine.Bases;

namespace Chess.Assets.ChessPieces;

public class Pawn(char symbol, ConsoleColor color, byte x, byte y) : BaseUIObject(symbol, color, x, y)
{
    public bool HasMoved { get; set; } = false;
}
