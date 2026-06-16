using System;
using Chess.Engine.Bases;

namespace Chess.Assets.ChessPieces;

public class Blank(char symbol, ConsoleColor color, int x, int y) : BaseUIObject(symbol, color, x, y)
{
}
