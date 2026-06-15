using System;
using Chess.Engine.Bases;

namespace Chess.Objects;

public class Cursor(char symbol, ConsoleColor color, byte x, byte y) : BaseUIObject(symbol, color, x, y)
{
    public ConsoleColor BackgroundColor { get; set; } = ConsoleColor.Gray;
}
