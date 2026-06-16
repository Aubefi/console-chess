using System;

namespace Chess.Engine.Bases;

public class BaseCursor(char symbol, ConsoleColor color, int x, int y) : BaseUIObject(symbol, color, x, y)
{
}
