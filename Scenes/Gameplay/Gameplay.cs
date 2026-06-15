using System;
using System.Collections.Generic;
using Chess.Assets.ChessPieces;
using Chess.Engine.Bases;

namespace Chess.Scenes.Gameplay;

public sealed class Gameplay : BaseScene
{
    public override List<BaseBehavior> Behaviors { get; protected set; } = [];

    private readonly Board _board = new();
    private readonly BoardRenderer _boardRenderer = new();
    private readonly BoardNavigation _boardNavigation = new();
    private readonly BoardCursor _cursor = new(char.MinValue, ConsoleColor.Gray, 0, 0);

    public Gameplay()
    {
        _cursor.SetBackgroundColor(ConsoleColor.DarkBlue);

        InitializeBehaviors();
        InitializeDependencies();

        BoardNavigation.SquareObjectInteractionEvent += OnSquareObjectInteractionEvent;
    }

    private void OnSquareObjectInteractionEvent(BaseUIObject @object)
    {
        if (@object is ChessPiece piece)
        {
            if (_cursor.IsHoldingChessPiece)
            {
                _cursor.SetSymbol(char.MinValue);
                _cursor.SetBackgroundColor(ConsoleColor.DarkBlue);
                _cursor.SetColor(ConsoleColor.Gray);
                _cursor.SelectedPiece = null;
                _cursor.IsHoldingChessPiece = false;
            }
            else
            {
                _cursor.SetSymbol(piece.Symbol);
                _cursor.SetBackgroundColor(ConsoleColor.DarkYellow);

                var color = piece.Color == ConsoleColor.White
                    ? piece.Color
                    : ConsoleColor.Black;

                _cursor.SetColor(color);
                _cursor.SelectedPiece = piece;
                _cursor.IsHoldingChessPiece = true;
            }
        }
    }

    protected override void InitializeBehaviors()
    {
        Behaviors.Add(_board);
        Behaviors.Add(_boardNavigation);
    }

    protected override void InitializeDependencies()
    {
        _boardRenderer.Cursor = _cursor;

        _boardNavigation.Cursor = _cursor;

        _board.Renderer = _boardRenderer;
        _board.Navigation = _boardNavigation;
    }
}
