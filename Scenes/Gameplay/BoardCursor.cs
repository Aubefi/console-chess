using System;
using Chess.Engine.Bases;
using Chess.GameObjects.ChessPieces;

namespace Chess.Scenes.Gameplay;

public class BoardCursor : BaseCursor
{
    public override Position Pos
    {
        get;
        protected set
        {
            LastPosition = field;
            field = value;
        }
    }

    public Position LastPosition { get; set; }
    public ChessPiece? GrabbedPiece { get; set; }

    public BoardCursor(char symbol, ConsoleColor color, int x, int y) : base(symbol, color, x, y)
    {
        Pos = new(x, y);
        LastPosition = Pos;
        GrabbedPiece = null;
    }

    public bool IsHoldingPiece
    {
        get => field = GrabbedPiece != null;
        private set;
    }
    public bool HasMoved
    {
        get => field = LastPosition != Pos;
        private set;
    }

    public bool HasPickedPieceUp
    {
        get => field = IsHoldingPiece && !HasMoved;
        private set;
    }
    public bool IsMovingPieceAround
    {
        get => field = IsHoldingPiece && HasMoved;
        private set;
    }
    public bool HasMovedPiece
    {
        get => field = !IsHoldingPiece && !HasMoved;
        private set;
    }
}
