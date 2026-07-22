using Chess.Engine;
using Chess.Engine.Bases;
using Chess.Settings;

namespace Chess.Scenes.Gameplay;

public sealed class OptionsInputs : BaseBehavior
{
    public OptionsCursor Cursor { get; set; } = null!;

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
                if (Cursor.Pos.Y < Cursor.MaxIndex)
                {
                    Cursor.SetPosition(new(Cursor.Pos.X, Cursor.Pos.Y + 1));
                }
                break;

            case InputMap.Interact:
                if (Cursor.Pos.Y == 1)
                {
                    Locale.SwapLanguage();
                }
                break;

            case InputMap.Escape:
                Tree.ChangeSceneTo(Tree.Scenes["Title"]);
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
