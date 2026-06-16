using System;
using Chess.Assets;

namespace Chess.Engine.Bases;

public class BaseCursor(char symbol, ConsoleColor color, byte x, byte y) : BaseUIObject(symbol, color, x, y)
{
    public ConsoleColor BackgroundColor { get; protected set; } = Colors.Cursor["Default"];
    public virtual void SetBackgroundColor(ConsoleColor color)
        => BackgroundColor = color;
}
