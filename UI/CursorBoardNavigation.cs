using System;
using Chess.Engine;
using Chess.Objects;

namespace Chess.UI;

public class CursorBoardNavigation : BaseBehavior
{
    public required Board Board { get; set; }
    public required Cursor Cursor { get; set; }

    public static event Action<BaseUIObject>? PlayerSelectedPieceEvent;

    public override void Update()
    {
        var keyInfo = Console.ReadKey(true);

        switch (keyInfo.Key)
        {
            case ConsoleKey.UpArrow:
            case ConsoleKey.W:
                if (Cursor.Coordinates.Y > 0) Cursor.SetY((byte)(Cursor.Coordinates.Y - 1));
                break;

            case ConsoleKey.DownArrow:
            case ConsoleKey.S:
                if (Cursor.Coordinates.Y < 7) Cursor.SetY((byte)(Cursor.Coordinates.Y + 1));
                break;

            case ConsoleKey.LeftArrow:
            case ConsoleKey.A:
                if (Cursor.Coordinates.X > 0) Cursor.SetX((byte)(Cursor.Coordinates.X - 1));
                break;

            case ConsoleKey.RightArrow:
            case ConsoleKey.D:
                if (Cursor.Coordinates.X < 7) Cursor.SetX((byte)(Cursor.Coordinates.X + 1));
                break;

            case ConsoleKey.Spacebar:
            case ConsoleKey.Enter:
                var piece = Board.GetPieceByCoordinates(Cursor.Coordinates);
                PlayerSelectedPieceEvent?.Invoke(piece);
                break;

            default:
                break;
        }
    }
}
