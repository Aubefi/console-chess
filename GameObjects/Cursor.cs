using System;
using Chess.UI;

namespace Chess.Objects;

public class Cursor : BaseUIObject
{
    public Cursor(char symbol, ConsoleColor color, byte x, byte y) : base(symbol, color, x, y)
    {
        CursorBoardNavigation.PlayerSelectedPieceEvent += OnPlayerSelectedPieceEvent;
    }

    public bool IsHoldingPiece { get; set; }

    public ConsoleColor BackgroundColor { get; set; } = ConsoleColor.DarkBlue;

    private void OnPlayerSelectedPieceEvent(BaseUIObject piece)
    {
        if (IsHoldingPiece)
        {
            IsHoldingPiece = false;
            BackgroundColor = ConsoleColor.Blue;
        }
        else if (piece is not EmptySquare)
        {
            Symbol = piece.Symbol;
            BackgroundColor = ConsoleColor.DarkYellow;
            IsHoldingPiece = true;
        }
    }

    public void SetSymbol(char symbol)
    {
        if (IsHoldingPiece is false)
        {
            Symbol = symbol;
        }
    }
}
