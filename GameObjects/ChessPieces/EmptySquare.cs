using System;

namespace Chess.Objects;

public class EmptySquare(char symbol, ConsoleColor color, byte x, byte y) : BaseUIObject(symbol, color, x, y)
{
}
