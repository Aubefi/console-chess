using System;
using Chess.Objects;

namespace Chess.Graphics;

public class BoardRenderer
{
    public required BaseUIObject[,] GridObjects;
    public required Cursor Cursor;

    private Position _lastCursorPos;
    private bool _isFirstRender = true;

    public BoardRenderer()
    {
        _lastCursorPos = new Position(0, 0);
    }

    public void RenderBoard()
    {
        if (_isFirstRender)
        {
            RenderFullBoard();
            _isFirstRender = false;
            _lastCursorPos = Cursor.Coordinates;
            return;
        }

        if (Cursor.Coordinates != _lastCursorPos)
        {
            Console.SetCursorPosition(_lastCursorPos.X * 3, _lastCursorPos.Y);

            Console.ResetColor();
            Console.ForegroundColor = GridObjects[_lastCursorPos.Y, _lastCursorPos.X].Color;
            Console.Write($" {GridObjects[_lastCursorPos.Y, _lastCursorPos.X].Symbol} ");

            Console.SetCursorPosition(Cursor.Coordinates.X * 3, Cursor.Coordinates.Y);

            Console.BackgroundColor = Cursor.BackgroundColor;
            Cursor.SetSymbol(GridObjects[Cursor.Coordinates.Y, Cursor.Coordinates.X].Symbol);
            Console.Write($" {Cursor.Symbol} ");

            Console.ResetColor();

            _lastCursorPos = Cursor.Coordinates;
        }
    }

    public void RenderFullBoard()
    {
        Console.SetCursorPosition(0, 0);

        for (byte i = 0; i < 8; i++)
        {
            for (byte j = 0; j < 8; j++)
            {
                if (i == Cursor.Coordinates.Y && j == Cursor.Coordinates.X)
                {
                    Console.BackgroundColor = Cursor.BackgroundColor;
                    Cursor.SetSymbol(GridObjects[i, j].Symbol);
                    Console.Write($" {Cursor.Symbol} ");
                }
                else
                {
                    Console.ForegroundColor = GridObjects[i, j].Color;
                    Console.Write($" {GridObjects[i, j].Symbol} ");
                }
                Console.ResetColor();
            }
            Console.Write("\n");
        }
    }
}
