using System;
using Chess.Engine;
using Chess.Engine.Bases;

namespace Chess.Scenes.Gameplay;

public sealed class GameplayInputs : BaseBehavior
{
    public BaseUIObject[,] BoardObjects { get; set; } = null!;
    public BoardCursor Cursor { get; set; } = null!;

    public static event Action<BaseUIObject>? SquareInteractionEvent;

    public GameplayInputs()
    {
        Input.InputAction += InputAction;
    }

    private void InputAction(InputMap input)
    {
        switch (input)
        {
            case InputMap.Up:
                if (Cursor.Pos.Y > 0)
                {
                    Cursor.SetPosition(new(Cursor.Pos.X, Cursor.Pos.Y - 1));
                }
                break;

            case InputMap.Left:
                if (Cursor.Pos.X > 0)
                {
                    Cursor.SetPosition(new(Cursor.Pos.X - 1, Cursor.Pos.Y));
                }
                break;

            case InputMap.Down:
                if (Cursor.Pos.Y < 7)
                {
                    Cursor.SetPosition(new(Cursor.Pos.X, Cursor.Pos.Y + 1));
                }
                break;

            case InputMap.Right:
                if (Cursor.Pos.X < 7)
                {
                    Cursor.SetPosition(new(Cursor.Pos.X + 1, Cursor.Pos.Y));
                }
                break;

            case InputMap.Interact:
                Cursor.SetPosition(new(Cursor.Pos.X, Cursor.Pos.Y));
                var interactedObject = BoardObjects[Cursor.Pos.Y, Cursor.Pos.X];
                SquareInteractionEvent?.Invoke(interactedObject);
                break;

            default:
            break;
        }
    }

    public override void Finish()
    {
        Input.InputAction -= InputAction;
    }
}
