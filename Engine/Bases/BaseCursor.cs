using System;

namespace Chess.Engine.Bases;

public class BaseCursor(char symbol, ConsoleColor color, byte x, byte y) : BaseUIObject(symbol, color, x, y)
{
    public ConsoleColor BackgroundColor { get; protected set; } = ConsoleColor.DarkBlue;
    public virtual void SetBackgroundColor(ConsoleColor color)
        => BackgroundColor = color;
}
