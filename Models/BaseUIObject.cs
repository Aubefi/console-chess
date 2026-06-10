using System;

namespace Chess.Models;

public abstract class BaseUIObject(char symbol, ConsoleColor color, byte x, byte y)
{
    public char Symbol { get; protected set; } = symbol;

    public ConsoleColor Color { get; protected set; } = color;

    public Position Coordinates { get; protected set; } = new Position(x, y);

    public record struct Position(byte X, byte Y);
}
