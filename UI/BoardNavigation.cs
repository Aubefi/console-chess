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
                if (cursor.Coordinates.Y > 0) cursor.SetY((byte)(cursor.Coordinates.Y - 1));
                break;
            case ConsoleKey.LeftArrow:
                if (cursor.Coordinates.X > 0) cursor.SetX((byte)(cursor.Coordinates.X - 1));
                break;
            case ConsoleKey.RightArrow:
                if (cursor.Coordinates.X < 7) cursor.SetX((byte)(cursor.Coordinates.X + 1));
                break;
            case ConsoleKey.DownArrow:
                if (cursor.Coordinates.Y < 7) cursor.SetY((byte)(cursor.Coordinates.Y + 1));
                break;
            default:
                break;
        }
    }
}
