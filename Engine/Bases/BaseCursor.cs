using System;

namespace Chess.Engine.Bases;

public abstract class BaseCursor(char symbol, ConsoleColor color, int x, int y)
: BaseUIObject(symbol, color, x, y)
{
}
