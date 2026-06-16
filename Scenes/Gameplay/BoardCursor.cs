using System;
using Chess.Assets.ChessPieces;
using Chess.Engine.Bases;

namespace Chess.Scenes.Gameplay;

public class BoardCursor(char symbol, ConsoleColor color, int x, int y) : BaseCursor(symbol, color, x, y)
{
    public ChessPiece? SelectedPiece { get; set; } = null;
    public bool IsHoldingChessPiece { get; set; } = false;
}
