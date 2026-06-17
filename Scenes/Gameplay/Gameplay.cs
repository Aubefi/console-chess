using System.Collections.Generic;
using Chess.Assets;
using Chess.Engine.Bases;

namespace Chess.Scenes.Gameplay;

public sealed class Gameplay : BaseScene
{
    public override List<BaseBehavior> Behaviors { get; protected set; } = [];

    private readonly Board _board = new();
    private readonly BoardRenderer _boardRenderer = new();
    private readonly BoardNavigation _boardNavigation = new();
    private readonly BoardInteraction _boardInteraction = new();
    private readonly BoardCursor _boardCursor = new(char.MinValue, Colors.Default["Gray"], 0, 0);

    public Gameplay()
    {
        _boardCursor.SetBackgroundColor(Colors.Cursor["Default"]);

        InitializeBehaviors();
        InitializeDependencies();
    }

    protected override void InitializeBehaviors()
    {
        Behaviors.Add(_board);
        Behaviors.Add(_boardRenderer);
        Behaviors.Add(_boardNavigation);
    }

    protected override void InitializeDependencies()
    {
        _boardRenderer.Cursor = _boardCursor;
        _boardNavigation.Cursor = _boardCursor;
        _boardInteraction.Cursor = _boardCursor;

        _boardRenderer.BoardObjects = _board.BoardObjects;
        _boardNavigation.BoardObjects = _board.BoardObjects;
        _boardInteraction.BoardObjects = _board.BoardObjects;
    }
}
