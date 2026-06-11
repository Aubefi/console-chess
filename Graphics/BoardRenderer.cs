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
                Console.ForegroundColor = gridObjects[i, j].Color;

                if (i == cursor.Coordinates.Y && j == cursor.Coordinates.X)
                {
                    Console.BackgroundColor = ConsoleColor.Blue;
                    cursor.SetSymbol(gridObjects[i, j].Symbol);
                    Console.Write($" {cursor.Symbol} ");
                }
                else
                {
                    Console.Write($" {gridObjects[i, j].Symbol} ");
                }

                Console.ResetColor();
            }
            Console.Write("\n");
        }
    }
}
