using System.Collections.Generic;
using Chess.Assets;
using Chess.GameObjects.ChessPieces;
using Chess.Engine.Bases;

namespace Chess.Scenes.Gameplay;

public sealed class Gameplay : BaseScene
{
    public override List<BaseBehavior> Behaviors { get; protected set; } = [];

    private readonly Board _board = new();
    private readonly BoardRenderer _boardRenderer = new();
    private readonly BoardNavigation _boardNavigation = new();
    private readonly BoardCursor _cursor = new(char.MinValue, Colors.Default["Gray"], 0, 0);

    public Gameplay()
    {
        _cursor.SetBackgroundColor(Colors.Cursor["Default"]);

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
                _cursor.SetBackgroundColor(Colors.Cursor["Default"]);
                _cursor.SetColor(Colors.Default["Gray"]);

                var allowedSquares = _cursor.SelectedPiece?.GetAllowedSquares(_board.BoardObjects);

                if (allowedSquares is not null)
                {
                    foreach (var sqr in allowedSquares)
                    {
                        _board.BoardObjects[pos.Y, pos.X].RemoveBackgroundColor();
                    }
                }

                _cursor.SelectedPiece = null;
                _cursor.IsHoldingChessPiece = false;
            }
            else
            {
                _cursor.SetSymbol(piece.Symbol);
                _cursor.SetBackgroundColor(Colors.Cursor["PieceSelected"]);

                var color = piece.Color == Colors.Pieces["White"]
                    ? Colors.Pieces["WhiteSelected"]
                    : Colors.Pieces["BlackSelected"];

                _cursor.SetColor(color);
                _cursor.SelectedPiece = piece;
                _cursor.IsHoldingChessPiece = true;

                var allowedSquares = piece.GetAllowedSquares(_board.BoardObjects);
                foreach (var sqr in allowedSquares)
                {
                    _board.BoardObjects[sqr.Y, sqr.X].SetBackgroundColor(Colors.Square["AllowedSquare"]);
                }
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
