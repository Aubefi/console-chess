using System;
using Chess.Engine.Bases;
using Chess.Objects;

namespace Chess.Scenes.Gameplay;

public class BoardNavigation : BaseBehavior
{
    public BaseUIObject[,] BoardObjects { get; set; } = null!;
    public Cursor BoardCursor { get; set; } = null!;

    public static event Action<BaseUIObject>? PlayerSelectedPieceEvent;

    public override void Update()
    {
        var keyInfo = Console.ReadKey(true);

        switch (keyInfo.Key)
        {
            case ConsoleKey.UpArrow:
            case ConsoleKey.W:
                if (BoardCursor.Pos.Y > 0)
                {
                    BoardCursor.SetPosition(
                        new Position(BoardCursor.Pos.X, (byte)(BoardCursor.Pos.Y - 1))
                    );
                }
                break;

            case ConsoleKey.DownArrow:
            case ConsoleKey.S:
                if (BoardCursor.Pos.Y < 7)
                {
                    BoardCursor.SetPosition(
                        new Position(BoardCursor.Pos.X, (byte)(BoardCursor.Pos.Y + 1))
                    );
                }
                break;

            case ConsoleKey.LeftArrow:
            case ConsoleKey.A:
                if (BoardCursor.Pos.X > 0)
                {
                    BoardCursor.SetPosition(
                        new Position((byte)(BoardCursor.Pos.X - 1), BoardCursor.Pos.Y)
                    );
                }
                break;

            case ConsoleKey.RightArrow:
            case ConsoleKey.D:
                if (BoardCursor.Pos.X < 7)
                {
                    BoardCursor.SetPosition(
                        new Position((byte)(BoardCursor.Pos.X + 1), BoardCursor.Pos.Y)
                    );
                }
                break;

            case ConsoleKey.Spacebar:
            case ConsoleKey.Enter:
                var piece = BoardObjects[BoardCursor.Pos.Y, BoardCursor.Pos.X];
                PlayerSelectedPieceEvent?.Invoke(piece);
                break;

            default:
                break;
        }
    }
}
