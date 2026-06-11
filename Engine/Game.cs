using System;
using System.Collections.Generic;
using Chess.Objects;
using Chess.UI;

namespace Chess.Engine;

public sealed class Game : BaseObject
{
    private readonly List<BaseObject> _baseObjects = [];
    private readonly List<BaseBehavior> _baseBehaviors = [];

    private readonly Cursor _cursor;
    private readonly Board _board;

    private readonly CursorBoardNavigation _cursorBoardNavigation;

    private readonly Start _start;
    private readonly Update _update;
    private readonly Finish _finish;

    public Game()
    {
        _cursor = new(' ', ConsoleColor.Gray, 0, 0);
        _board = new Board { BoardCursor = _cursor };

        _cursorBoardNavigation = new CursorBoardNavigation { Board = _board, Cursor = _cursor };

        _start = new Start { BaseBehaviors = _baseBehaviors };
        _update = new Update { BaseBehaviors = _baseBehaviors };
        _finish = new Finish { BaseBehaviors = _baseBehaviors };

        InitializeBaseObjects();
        InitializeBaseBehaviors();
    }

    public override void Run()
    {
        foreach (var obj in _baseObjects)
        {
            obj.Run();
        }
    }

    private void InitializeBaseObjects()
    {
        _baseObjects.Add(_start);
        _baseObjects.Add(_update);
        _baseObjects.Add(_finish);
    }

    private void InitializeBaseBehaviors()
    {
        _baseBehaviors.Add(_board);
        _baseBehaviors.Add(_cursor);
        _baseBehaviors.Add(_cursorBoardNavigation);
    }
}
