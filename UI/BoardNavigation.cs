using System;
using Chess.Objects;

namespace Chess.UI;

public class BoardNavigation
{
    public static void ReadPlayerInput(Board board, Cursor cursor)
    {
        var keyInfo = Console.ReadKey(true);

        switch (keyInfo.Key)
        {
            case ConsoleKey.UpArrow:
            case ConsoleKey.W:
                if (cursor.Coordinates.Y > 0) cursor.SetY((byte)(cursor.Coordinates.Y - 1));
                break;

            case ConsoleKey.LeftArrow:
            case ConsoleKey.A:
                if (cursor.Coordinates.X > 0) cursor.SetX((byte)(cursor.Coordinates.X - 1));
                break;

            case ConsoleKey.RightArrow:
            case ConsoleKey.D:
                if (cursor.Coordinates.X < 7) cursor.SetX((byte)(cursor.Coordinates.X + 1));
                break;

            case ConsoleKey.DownArrow:
            case ConsoleKey.S:
                if (cursor.Coordinates.Y < 7) cursor.SetY((byte)(cursor.Coordinates.Y + 1));
                break;
            default:
                break;
        }
    }
}
