using System;
using Chess.Engine.Bases;

namespace Chess.Assets.ChessPieces;

public class Blank(char symbol, ConsoleColor color, byte x, byte y) : BaseUIObject(symbol, color, x, y)
{
}
