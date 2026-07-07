using System;
using Chess.Engine.Bases;

namespace Chess.Scenes.Gameplay;

public sealed class GameplayInputs : BaseBehavior
{
    public BaseUIObject[,] BoardObjects { get; set; } = null!;
    public BoardCursor Cursor { get; set; } = null!;

    public static event Action<BaseUIObject>? SquareInteractionEvent;

    public static event Action? RedrawBoardEvent;

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
                        new(Cursor.Pos.X, Cursor.Pos.Y - 1)
                    );
                }
                break;

            case ConsoleKey.DownArrow:
            case ConsoleKey.S:
                if (Cursor.Pos.Y < 7)
                {
                    Cursor.SetPosition(
                        new(Cursor.Pos.X, Cursor.Pos.Y + 1)
                    );
                }
                break;

            case ConsoleKey.LeftArrow:
            case ConsoleKey.A:
                if (Cursor.Pos.X > 0)
                {
                    Cursor.SetPosition(
                        new(Cursor.Pos.X - 1, Cursor.Pos.Y)
                    );
                }
                break;

            case ConsoleKey.RightArrow:
            case ConsoleKey.D:
                if (Cursor.Pos.X < 7)
                {
                    Cursor.SetPosition(
                        new(Cursor.Pos.X + 1, Cursor.Pos.Y)
                    );
                }
                break;

            case ConsoleKey.Spacebar:
            case ConsoleKey.Enter:
                Cursor.SetPosition(new(Cursor.Pos.X, Cursor.Pos.Y));
                var interactedObject = BoardObjects[Cursor.Pos.Y, Cursor.Pos.X];
                SquareInteractionEvent?.Invoke(interactedObject);
                break;

            case ConsoleKey.R:
                RedrawBoardEvent?.Invoke();
                break;

            default:
                break;
        }
    }
}
