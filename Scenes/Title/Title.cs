using Chess.Assets;
using Chess.Engine.Bases;
using Chess.Scenes.Gameplay;

namespace Chess.Scenes.Title;

public sealed class Title : BaseScene
{
    private readonly TitleCursor _titleCursor = new(char.MinValue, Colors.Cursor["Foreground"], 0, 0);
    private readonly TitleRenderer _titleRenderer = new();
    private readonly TitleInputs _titleInputs = new();

    public Title()
    {
        _titleCursor.SetBackgroundColor(Colors.Cursor["Background"]);

        InitializeBehaviors();
        InitializeDependencies();
    }

    protected override void InitializeBehaviors()
    {
        Behaviors.Add(_titleRenderer);
        Behaviors.Add(_titleInputs);
    }

    protected override void InitializeDependencies()
    {
        _titleRenderer.Cursor = _titleCursor;
        _titleInputs.Cursor = _titleCursor;
    }
}
