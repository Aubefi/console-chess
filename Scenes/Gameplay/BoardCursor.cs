using System;
using Chess.Engine.Bases;
using Chess.GameObjects.ChessPieces;

namespace Chess.Scenes.Gameplay;

public class BoardCursor(char symbol, ConsoleColor color, int x, int y) : BaseCursor(symbol, color, x, y)
{
    public ChessPiece? GrabbedPiece { get; set; } = null;

    public bool IsHoldingChessPiece
    {
        get => field = GrabbedPiece != null;
        private set;
    }
}
