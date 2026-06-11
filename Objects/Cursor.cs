using System;

namespace Chess.Objects;

public class Cursor(char symbol, ConsoleColor color, byte x, byte y) : BaseUIObject(symbol, color, x, y)
{
    public void SetSymbol(char symbol) => Symbol = symbol;

    public void SetX(byte x) => Coordinates = new(x, Coordinates.Y);
    public void SetY(byte y) => Coordinates = new(Coordinates.X, y);
}
