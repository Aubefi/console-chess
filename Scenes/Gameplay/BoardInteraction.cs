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
                TryCapturePiece(piece);
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

    private void TryCapturePiece(ChessPiece piece)
    {
        ResetCursorVisuals();

        RemovePieceLegalMovesVisual();

        Cursor.SelectedPiece = null;
    }

    private void TryMovePiece()
    {
        ResetCursorVisuals();

        var isMoveLegal = false;

        var legalMoves = Cursor.SelectedPiece!.GetLegalMoves(BoardObjects);

        foreach (var pos in legalMoves)
        {
            // Checks if the player is trying to move to a legal position
            if (Cursor.Pos == pos)
            {
                isMoveLegal = true;
            }

            BoardObjects[pos.Y, pos.X].RemoveBackgroundColor();
        }

        if (isMoveLegal)
        {
            var targetX = Cursor.Pos.X;
            var targetY = Cursor.Pos.Y;

            var originX = Cursor.SelectedPiece.Pos.X;
            var originY = Cursor.SelectedPiece.Pos.Y;

            var targetBlank = (Blank)BoardObjects[targetY, targetX];
            var originPiece = (ChessPiece)BoardObjects[originY, originX];

            // Update the internal positions
            targetBlank.SetPosition(new(originX, originY));
            originPiece.SetPosition(new(targetX, targetY));

            // Update the matrix
            BoardObjects[targetY, targetX] = originPiece;
            BoardObjects[originY, originX] = targetBlank;

            Cursor.SelectedPiece = null;
        }
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

        var legalMoves = piece.GetLegalMoves(BoardObjects);

        foreach (var pos in legalMoves)
        {
            BoardObjects[pos.Y, pos.X].SetBackgroundColor(Colors.Square["AllowedSquare"]);
        }
    }

    private void ResetCursorVisuals()
    {
        Cursor.SetSymbol(char.MinValue);
        Cursor.SetBackgroundColor(Colors.Cursor["Default"]);
        Cursor.SetColor(Colors.Default["Gray"]);
    }

    private void RemovePieceLegalMovesVisual()
    {
        var legalMovesPos = Cursor.SelectedPiece?.GetLegalMoves(BoardObjects);

        if (legalMovesPos is not null)
        {
            foreach (var pos in legalMovesPos)
            {
                BoardObjects[pos.Y, pos.X].RemoveBackgroundColor();
            }
        }
    }
}
