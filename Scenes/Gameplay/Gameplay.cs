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

        BoardNavigation.SquareInteractionEvent += HandleSquareInteraction;
    }

    private void HandleSquareInteraction(BaseUIObject interactedObject)
    {
        if (interactedObject is ChessPiece piece)
        {
            if (_cursor.IsHoldingChessPiece)
            {
                _cursor.SetSymbol(char.MinValue);
                _cursor.SetBackgroundColor(Colors.Cursor["Default"]);
                _cursor.SetColor(Colors.Default["Gray"]);

                var legalMovesPos = _cursor.SelectedPiece?.GetLegalMoves(_board.BoardObjects);

                if (legalMovesPos is not null)
                {
                    foreach (var pos in legalMovesPos)
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

                var legalMoves = piece.GetLegalMoves(_board.BoardObjects);

                foreach (var pos in legalMoves)
                {
                    _board.BoardObjects[pos.Y, pos.X].SetBackgroundColor(Colors.Square["AllowedSquare"]);
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
