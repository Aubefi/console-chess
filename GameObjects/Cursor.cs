using System;

namespace Chess.Objects;

public class Cursor(char symbol, ConsoleColor color, byte x, byte y) : BaseUIObject(symbol, color, x, y)
{
    public void SetSymbol(char symbol) => Symbol = symbol;
}
