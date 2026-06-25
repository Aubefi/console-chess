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
        if (Cursor.IsHoldingPiece)
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
            GrabPiece(piece);
        }
    }

    private void TryCapturePiece(ChessPiece piece)
    {
        ResetCursor();

        if (Cursor.GrabbedPiece is not null)
        {
            var legalMoves = Cursor.GrabbedPiece.GetLegalMoves(BoardObjects);

            foreach (var pos in legalMoves)
            {
                BoardObjects[pos.Y, pos.X].RemoveBackgroundColor();
            }
        }
        Cursor.GrabbedPiece = null;
    }

    private void TryMovePiece()
    {
        var legalMoves = Cursor.GrabbedPiece!.GetLegalMoves(BoardObjects);

        if (!legalMoves.Contains(Cursor.Pos))
        {
            return;
        }

        ResetCursor();

        foreach (var pos in legalMoves)
        {
            BoardObjects[pos.Y, pos.X].RemoveBackgroundColor();
        }

        var targetX = Cursor.Pos.X;
        var targetY = Cursor.Pos.Y;

        var originX = Cursor.GrabbedPiece.Pos.X;
        var originY = Cursor.GrabbedPiece.Pos.Y;

        var targetBlank = (Blank)BoardObjects[targetY, targetX];
        var originPiece = (ChessPiece)BoardObjects[originY, originX];

        // Swap the objects internal positions
        targetBlank.SetPosition(new(originX, originY));
        originPiece.SetPosition(new(targetX, targetY));

        // Swap the board visible positions
        BoardObjects[targetY, targetX] = originPiece;
        BoardObjects[originY, originX] = targetBlank;

        Cursor.GrabbedPiece = null;
    }

    private void GrabPiece(ChessPiece piece)
    {
        Cursor.GrabbedPiece = piece;

        Cursor.SetSymbol(piece.Symbol);
        Cursor.SetBackgroundColor(Colors.Cursor["PieceSelected"]);

        var newCursorColor = piece.Color == Colors.Pieces["White"]
            ? Colors.Pieces["WhiteSelected"]
            : Colors.Pieces["BlackSelected"];

        Cursor.SetColor(newCursorColor);

        var legalMoves = piece.GetLegalMoves(BoardObjects);

        foreach (var pos in legalMoves)
        {
            BoardObjects[pos.Y, pos.X].SetBackgroundColor(Colors.Square["AllowedSquare"]);
        }
    }

    private void ResetCursor()
    {
        Cursor.SetSymbol(char.MinValue);
        Cursor.SetColor(Colors.Cursor["Foreground"]);
        Cursor.SetBackgroundColor(Colors.Cursor["Background"]);
    }
}
