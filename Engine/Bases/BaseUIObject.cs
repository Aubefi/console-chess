using System;

namespace Chess.Engine.Bases;

public record struct Position(int X, int Y);

public abstract class BaseUIObject(char symbol, ConsoleColor color, int x, int y)
{
    public virtual char Symbol { get; protected set; } = symbol;
    public virtual void SetSymbol(char symbol)
        => Symbol = symbol;

    public virtual ConsoleColor Color { get; protected set; } = color;
    public virtual void SetColor(ConsoleColor color)
        => Color = color;

    public virtual ConsoleColor? BackgroundColor { get; protected set; } = null;
    public virtual void SetBackgroundColor(ConsoleColor color)
        => BackgroundColor = color;
    public virtual void RemoveBackgroundColor()
        => BackgroundColor = null;

    public virtual Position Pos { get; protected set; } = new(x, y);
    public virtual void SetPosition(Position pos)
        => Pos = pos;
}
