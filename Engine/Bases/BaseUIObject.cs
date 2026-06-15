using System;

namespace Chess.Engine.Bases;

public record struct Position(byte X, byte Y);

public abstract class BaseUIObject(char symbol, ConsoleColor color, byte x, byte y)
{
    public char Symbol { get; protected set; } = symbol;
    public virtual void SetSymbol(char symbol)
        => Symbol = symbol;

    public ConsoleColor Color { get; protected set; } = color;
    public virtual void SetColor(ConsoleColor color)
        => Color = color;

    public Position Pos { get; protected set; } = new Position(x, y);
    public virtual void SetPosition(Position pos)
        => Pos = pos;
}
