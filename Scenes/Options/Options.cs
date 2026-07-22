using Chess.Assets;
using Chess.Engine.Bases;
using Chess.Scenes.Gameplay;

namespace Chess.Scenes.Options;

public sealed class Options : BaseScene
{
    private readonly OptionsCursor _optionsCursor = new(char.MinValue, Colors.Cursor["Foreground"], 0, 0);
    private readonly OptionsRenderer _optionsRenderer = new();
    private readonly OptionsInputs _optionsInputs = new();

    public Options()
    {
        _optionsCursor.SetBackgroundColor(Colors.Cursor["Background"]);

        InitializeBehaviors();
        InitializeDependencies();
    }

    protected override void InitializeBehaviors()
    {
        Behaviors.Add(_optionsRenderer);
        Behaviors.Add(_optionsInputs);
    }

    protected override void InitializeDependencies()
    {
        _optionsRenderer.Cursor = _optionsCursor;
        _optionsInputs.Cursor = _optionsCursor;
    }
}
