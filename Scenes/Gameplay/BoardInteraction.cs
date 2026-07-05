using Chess.Assets;
using Chess.Engine.Bases;
using Chess.GameObjects.ChessPieces;

namespace Chess.Scenes.Gameplay;

public sealed class BoardInteraction
{
    public BaseUIObject[,] BoardObjects { get; set; } = null!;
    public BoardCursor Cursor { get; set; } = null!;

    public GameplayState State { get; set; } = null!;

    public BoardInteraction()
    {
        BoardNavigation.SquareInteractionEvent += HandleSquareInteraction;
    }

    private void HandleSquareInteraction(BaseUIObject interactedObject)
    {
        if (Cursor.IsHoldingPiece)
        {
            if (interactedObject == Cursor.GrabbedPiece)
            {
                CancelGrab();
                return;
            }

            bool isMoveSuccessful = interactedObject is ChessPiece && interactedObject.Color != State.CurrentPlayerColor
                ? TryCapturePiece()
                : TryMovePiece();

            if (isMoveSuccessful)
            {
                State.IsWhiteToMove = !State.IsWhiteToMove;
            }
        }
        else if (interactedObject is ChessPiece piece && interactedObject.Color == State.CurrentPlayerColor)
        {
            TryGrabPiece(piece);
        }
    }

    private void CancelGrab()
    {
        ResetCursor();

        foreach (var pos in Cursor.GrabbedPiece!.GetLegalMoves(BoardObjects))
        {
            BoardObjects[pos.Y, pos.X].RemoveBackgroundColor();
        }
        Cursor.GrabbedPiece = null;
    }

    private bool TryCapturePiece()
    {
        var legalMoves = Cursor.GrabbedPiece!.GetLegalMoves(BoardObjects);

        if (legalMoves.Contains(Cursor.Pos) is false)
        {
            return false;
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

        var originPiece = (ChessPiece)BoardObjects[originY, originX];

        originPiece.SetPosition(new(targetX, targetY));

        BoardObjects[targetY, targetX] = originPiece;

        BoardObjects[originY, originX] = new Blank(originX, originY);

        Cursor.GrabbedPiece = null;

        return true;
    }

    private bool TryMovePiece()
    {
        var legalMoves = Cursor.GrabbedPiece!.GetLegalMoves(BoardObjects);

        if (legalMoves.Contains(Cursor.Pos) is false)
        {
            return false;
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
        return true;
    }

    private bool TryGrabPiece(ChessPiece piece)
    {
        var legalMoves = piece.GetLegalMoves(BoardObjects);

        if (legalMoves.Count == 0)
        {
            return false;
        }

        foreach (var pos in legalMoves)
        {
            BoardObjects[pos.Y, pos.X].SetBackgroundColor(Colors.Square["AllowedSquare"]);
        }

        var newCursorColor = piece.Color == Colors.Pieces["White"]
            ? Colors.Pieces["WhiteSelected"]
            : Colors.Pieces["BlackSelected"];

        Cursor.SetColor(newCursorColor);
        Cursor.GrabbedPiece = piece;
        Cursor.SetSymbol(piece.Symbol);
        Cursor.SetBackgroundColor(Colors.Cursor["PieceSelected"]);

        return true;
    }

    private void ResetCursor()
    {
        Cursor.SetSymbol(char.MinValue);
        Cursor.SetColor(Colors.Cursor["Foreground"]);
        Cursor.SetBackgroundColor(Colors.Cursor["Background"]);
    }
}
