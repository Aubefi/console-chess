using System;
using Chess.Objects;

namespace Chess.Graphics;

public class BoardRenderer
{
    public static void RenderBoard(BaseUIObject[,] gridObjects, Cursor cursor)
    {
        Console.SetCursorPosition(0, 0);

        for (byte i = 0; i < 8; i++)
        {
            for (byte j = 0; j < 8; j++)
            {
                var onCursorPosition = (cursor.Coordinates.X == j) && (cursor.Coordinates.Y == i);

                if (onCursorPosition) Console.BackgroundColor = ConsoleColor.Blue;

                if (gridObjects[i, j] is not null)
                {
                    Console.ForegroundColor = gridObjects[i, j].Color;

                    if (onCursorPosition)
                    {
                        Console.ForegroundColor = gridObjects[i, j].Color is ConsoleColor.White
                            ? ConsoleColor.White
                            : ConsoleColor.Black;
                        cursor.SetSymbol(gridObjects[i, j].Symbol);
                    }

                    Console.Write($" {gridObjects[i, j].Symbol} ");
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.White;

                    if (onCursorPosition)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkBlue;
                        cursor.SetSymbol('\u00B7');
                    }

                    Console.Write(" \u00B7 ");
                }

                Console.ResetColor();
            }
            Console.Write("\n");
        }
    }
}
