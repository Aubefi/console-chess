using System;
using Chess.Assets;
using Chess.Engine.Bases;

namespace Chess.Scenes.Gameplay;

public class BoardRenderer : BaseRenderer
{
    protected override bool IsFirstRender { get; set; } = true;

    public BaseUIObject[,] BoardObjects { get; set; } = null!;
    public BoardCursor Cursor { get; set; } = null!;

    private Position _lastCursorPos = new(0, 0);
    private bool _wasHoldingChessPiece = false;

    public override void Render()
    {
        if (IsFirstRender)
        {
            FirstRender();
            return;
        }

        if (CanRender())
        {
            _wasHoldingChessPiece = Cursor.IsHoldingChessPiece;

            CleanLastCursorPosition();
            UpdateCursorVisualFeedback();
            UpdateSquaresVisualFeedbacks();
        }

        _lastCursorPos = Cursor.Pos;
    }

    private bool CanRender()
        => (Cursor.Pos == _lastCursorPos && Cursor.IsHoldingChessPiece && !_wasHoldingChessPiece)
        || (Cursor.Pos == _lastCursorPos && !Cursor.IsHoldingChessPiece && _wasHoldingChessPiece)
        || Cursor.Pos != _lastCursorPos;

    public override void FirstRender()
    {
        Console.SetCursorPosition(0, 0);

        _lastCursorPos = Cursor.Pos;

        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                if ((i == Cursor.Pos.Y) && (j == Cursor.Pos.X))
                {
                    if (Cursor.BackgroundColor is ConsoleColor color)
                    {
                        Console.BackgroundColor = color;
                    }

                    Console.ForegroundColor = BoardObjects[i, j].Color;
                }
                else
                {
                    Console.ForegroundColor = BoardObjects[i, j].Color;
                }

                Console.Write($" {BoardObjects[i, j].Symbol} ");

                Console.ResetColor();
            }
            Console.Write("\n");
        }
        IsFirstRender = false;

        Console.ResetColor();
    }

    private void CleanLastCursorPosition()
    {
        Console.SetCursorPosition(_lastCursorPos.X * 3, _lastCursorPos.Y);
        Console.ResetColor();

        var obj = BoardObjects[_lastCursorPos.Y, _lastCursorPos.X];

        Console.ForegroundColor = obj.Color;
        Console.Write($" {obj.Symbol} ");

        Console.ResetColor();
    }

    private void UpdateCursorVisualFeedback()
    {
        Console.SetCursorPosition(Cursor.Pos.X * 3, Cursor.Pos.Y);

        if (Cursor.BackgroundColor is ConsoleColor color)
        {
            Console.BackgroundColor = color;
        }

        var obj = BoardObjects[Cursor.Pos.Y, Cursor.Pos.X];

        Console.ForegroundColor = obj.Symbol == Symbols.Square[SquareObject.Blank] || Cursor.IsHoldingChessPiece
            ? Cursor.Color
            : obj.Color;

        var symbol = Cursor.Symbol is char.MinValue
            ? obj.Symbol
            : Cursor.Symbol;

        Console.Write($" {symbol} ");

        Console.ResetColor();
    }
}
