using System;
using System.Collections.Generic;
using Chess.Engine.Bases;
using Chess.Objects;

namespace Chess.Scenes.Gameplay;

public sealed class Gameplay : BaseScene
{
    public override List<BaseBehavior> Behaviors { get; protected set; } = [];

    private readonly Cursor _cursor = new(' ', ConsoleColor.Gray, 0, 0);

    private readonly Board _board = new();
    private readonly BoardRenderer _boardRenderer = new();
    private readonly BoardNavigation _boardNavigation = new();

    public Gameplay()
    {
        _cursor.BackgroundColor = ConsoleColor.DarkBlue;

        InitializeBehaviors();
        InitializeDependencies();
    }

    protected override void InitializeBehaviors()
    {
        Behaviors.Add(_board);
        Behaviors.Add(_boardNavigation);
    }

    protected override void InitializeDependencies()
    {
        _boardRenderer.BoardCursor = _cursor;

        _boardNavigation.BoardCursor = _cursor;

        _board.Renderer = _boardRenderer;
        _board.Navigation = _boardNavigation;
    }
}
