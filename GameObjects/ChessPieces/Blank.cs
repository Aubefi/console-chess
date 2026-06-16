using System;
using Chess.Engine.Bases;

namespace Chess.GameObjects.ChessPieces;

public class Blank(char symbol, ConsoleColor color, int x, int y) : BaseUIObject(symbol, color, x, y)
{
}
