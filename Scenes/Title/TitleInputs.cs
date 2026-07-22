using Chess.Engine;
using Chess.Engine.Bases;

namespace Chess.Scenes.Gameplay;

public sealed class TitleInputs : BaseBehavior
{
    public TitleCursor Cursor { get; set; } = null!;

    public override void Start()
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

            case InputMap.Down:
                if (Cursor.Pos.Y < 2)
                {
                    Cursor.SetPosition(new(Cursor.Pos.X, Cursor.Pos.Y + 1));
                }
                break;

            case InputMap.Interact:
                if (Cursor.Pos.Y == 0)
                {
                    Tree.SetCurrentScene(Tree.Scenes["Gameplay"]);
                }
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
