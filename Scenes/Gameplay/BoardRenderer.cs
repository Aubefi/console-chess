using System;
using Chess.Assets;
using Chess.Engine.Bases;
using Chess.Objects;

namespace Chess.Scenes.Gameplay;

public class BoardRenderer : BaseRenderer
{
    protected override bool IsFirstRender { get; set; } = true;

    public BaseUIObject[,] BoardObjects { get; set; } = null!;
    public Cursor BoardCursor { get; set; } = null!;

    private Position _lastCursorPos = new(0, 0);

    public override void Render()
    {
        if (IsFirstRender)
        {
            FirstRender();
            return;
        }

        if (BoardCursor.Pos != _lastCursorPos)
        {
            CleanLastCursorPosition();
            UpdateCursorVisualFeedback();
        }

        _lastCursorPos = BoardCursor.Pos;
    }

    public override void FirstRender()
    {
        Console.SetCursorPosition(0, 0);

        _lastCursorPos = BoardCursor.Pos;

        for (byte i = 0; i < 8; i++)
        {
            for (byte j = 0; j < 8; j++)
            {
                if ((i == BoardCursor.Pos.Y) && (j == BoardCursor.Pos.X))
                {
                    Console.BackgroundColor = BoardCursor.BackgroundColor;
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
        Console.ForegroundColor = BoardObjects[_lastCursorPos.Y, _lastCursorPos.X].Color;
        Console.Write($" {BoardObjects[_lastCursorPos.Y, _lastCursorPos.X].Symbol} ");

        Console.ResetColor();
    }

    private void UpdateCursorVisualFeedback()
    {
        Console.SetCursorPosition(BoardCursor.Pos.X * 3, BoardCursor.Pos.Y);

        Console.BackgroundColor = BoardCursor.BackgroundColor;

        var obj = BoardObjects[BoardCursor.Pos.Y, BoardCursor.Pos.X];

        Console.ForegroundColor = obj.Symbol == Symbols.Square[SquareObject.Blank]
            ? ConsoleColor.Blue
            : obj.Color;

        Console.Write($" {obj.Symbol} ");

        Console.ResetColor();
    }
}
