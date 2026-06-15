using System;
using Chess.Engine.Bases;

namespace Chess.Scenes.Gameplay;

public class BoardNavigation : BaseBehavior
{
    public BaseUIObject[,] BoardObjects { get; set; } = null!;
    public BoardCursor Cursor { get; set; } = null!;

    public static event Action<BaseUIObject>? SquareObjectInteractionEvent;

    public override void Update()
    {
        var input = Console.ReadKey(true);

        switch (input.Key)
        {
            case ConsoleKey.UpArrow:
            case ConsoleKey.W:
                if (Cursor.Pos.Y > 0)
                {
                    Cursor.SetPosition(
                        new Position(Cursor.Pos.X, (byte)(Cursor.Pos.Y - 1))
                    );
                }
                break;

            case ConsoleKey.DownArrow:
            case ConsoleKey.S:
                if (Cursor.Pos.Y < 7)
                {
                    Cursor.SetPosition(
                        new Position(Cursor.Pos.X, (byte)(Cursor.Pos.Y + 1))
                    );
                }
                break;

            case ConsoleKey.LeftArrow:
            case ConsoleKey.A:
                if (Cursor.Pos.X > 0)
                {
                    Cursor.SetPosition(
                        new Position((byte)(Cursor.Pos.X - 1), Cursor.Pos.Y)
                    );
                }
                break;

            case ConsoleKey.RightArrow:
            case ConsoleKey.D:
                if (Cursor.Pos.X < 7)
                {
                    Cursor.SetPosition(
                        new Position((byte)(Cursor.Pos.X + 1), Cursor.Pos.Y)
                    );
                }
                break;

            case ConsoleKey.Spacebar:
            case ConsoleKey.Enter:
                var @object = BoardObjects[Cursor.Pos.Y, Cursor.Pos.X];
                SquareObjectInteractionEvent?.Invoke(@object);
                break;

            default:
                break;
        }
    }
}
