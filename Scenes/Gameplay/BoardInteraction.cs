using Chess.Assets;
using Chess.Engine.Bases;
using Chess.GameObjects.ChessPieces;

namespace Chess.Scenes.Gameplay;

public sealed class BoardInteraction
{
    public BaseUIObject[,] BoardObjects { get; set; } = null!;
    public BoardCursor Cursor { get; set; } = null!;

    public BoardInteraction()
    {
        BoardNavigation.SquareInteractionEvent += HandleSquareInteraction;
    }

    private void HandleSquareInteraction(BaseUIObject interactedObject)
    {
        if (Cursor.IsHoldingChessPiece)
        {
            if (interactedObject is ChessPiece piece)
            {
                TryCapturePiece();
            }
            else
            {
                TryMovePiece();
            }
        }
        else if (interactedObject is ChessPiece piece)
        {
            HoldInteractedPiece(piece);
        }
    }

    private void TryCapturePiece()
    {
        Cursor.SetSymbol(char.MinValue);
        Cursor.SetBackgroundColor(Colors.Cursor["Default"]);
        Cursor.SetColor(Colors.Default["Gray"]);

        var legalMovesPos = Cursor.SelectedPiece?.GetLegalMoves(BoardObjects);

        if (legalMovesPos is not null)
        {
            foreach (var pos in legalMovesPos)
            {
                BoardObjects[pos.Y, pos.X].RemoveBackgroundColor();
            }
        }

        Cursor.SelectedPiece = null;
        Cursor.IsHoldingChessPiece = false;
    }

    private void TryMovePiece()
    {
    }

    private void HoldInteractedPiece(ChessPiece piece)
    {
        Cursor.SetSymbol(piece.Symbol);
        Cursor.SetBackgroundColor(Colors.Cursor["PieceSelected"]);

        var color = piece.Color == Colors.Pieces["White"]
            ? Colors.Pieces["WhiteSelected"]
            : Colors.Pieces["BlackSelected"];

        Cursor.SetColor(color);
        Cursor.SelectedPiece = piece;
        Cursor.IsHoldingChessPiece = true;

        var legalMoves = piece.GetLegalMoves(BoardObjects);

        foreach (var pos in legalMoves)
        {
            BoardObjects[pos.Y, pos.X].SetBackgroundColor(Colors.Square["AllowedSquare"]);
        }
    }
}
