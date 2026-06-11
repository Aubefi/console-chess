using System;

namespace Chess.Objects;

public record struct Position(byte X, byte Y);

public abstract class BaseUIObject(char symbol, ConsoleColor color, byte x, byte y)
{
    public char Symbol { get; protected set; } = symbol;

    public ConsoleColor Color { get; protected set; } = color;

    public Position Coordinates { get; protected set; } = new Position(x, y);

    public void SetPosition(Position pos) => Coordinates = pos;
    public void SetX(byte x) => Coordinates = new(x, Coordinates.Y);
    public void SetY(byte y) => Coordinates = new(Coordinates.X, y);
}
