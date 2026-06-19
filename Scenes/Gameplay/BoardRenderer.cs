using System;
using System.Collections.Generic;
using Chess.Assets;
using Chess.Engine.Bases;
using Chess.GameObjects.ChessPieces;

namespace Chess.Scenes.Gameplay;

public class BoardRenderer : BaseRenderer
{
    protected override bool IsFirstRender { get; set; } = true;

    public BaseUIObject[,] BoardObjects { get; set; } = null!;
    public BoardCursor Cursor { get; set; } = null!;

    private readonly BaseUIObject[,] _lastBoardObjects = new BaseUIObject[8, 8];
    private Position _lastCursorPos = new(0, 0);
    private bool _wasHoldingChessPiece = false;

    private readonly List<Position> _highlightedSquares = [];

    public override void Start()
    {
        Array.Copy(BoardObjects, _lastBoardObjects, BoardObjects.Length);
    }

    public override void Update()
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
            UpdatePiecesPositionFeedback();
        }

        _lastCursorPos = Cursor.Pos;
    }

    private bool CanRender()
        => (Cursor.Pos == _lastCursorPos && Cursor.IsHoldingChessPiece && !_wasHoldingChessPiece)
        || (Cursor.Pos == _lastCursorPos && !Cursor.IsHoldingChessPiece && _wasHoldingChessPiece)
        || Cursor.Pos != _lastCursorPos
        || SomePieceMoved();

    private bool SomePieceMoved()
    {
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                if (BoardObjects[i, j] != _lastBoardObjects[i, j])
                {
                    return true;
                }
            }
        }
        return false;
    }

    protected override void FirstRender()
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

    private void UpdateSquaresVisualFeedbacks()
    {
        (int x, int y) = Console.GetCursorPosition();

        var clearedList = false;
        var resetedList = false;

        foreach (var obj in BoardObjects)
        {
            if (obj.BackgroundColor is ConsoleColor color)
            {
                if (!clearedList)
                {
                    _highlightedSquares.Clear();
                    clearedList = true;
                }

                Console.SetCursorPosition(obj.Pos.X * 3, obj.Pos.Y);

                if (obj.Pos == Cursor.Pos)
                {
                    Console.BackgroundColor = Colors.Square["AllowedMovement"];
                    Console.ForegroundColor = Colors.Default["White"];
                    Console.Write($" {Cursor.Symbol} ");
                }
                else
                {
                    Console.BackgroundColor = color;
                    Console.ForegroundColor = Colors.Default["Black"];
                    Console.Write($" {obj.Symbol} ");
                }

                _highlightedSquares.Add(new Position(obj.Pos.X, obj.Pos.Y));
            }
            else if (_highlightedSquares.Contains(new Position(obj.Pos.X, obj.Pos.Y)) && obj.BackgroundColor is null)
            {
                if (!resetedList)
                {
                    resetedList = true;
                }

                Console.ForegroundColor = obj.Color;

                Console.SetCursorPosition(obj.Pos.X * 3, obj.Pos.Y);

                Console.Write($" {obj.Symbol} ");
            }
        }

        if (resetedList)
        {
            _highlightedSquares.Clear();
        }

        Console.SetCursorPosition(x, y);

        Console.ResetColor();
    }

    private void UpdatePiecesPositionFeedback()
    {
        for (int i = 0; i < 8; i++)
        {
            for (int j = 0; j < 8; j++)
            {
                if (BoardObjects[i, j] != _lastBoardObjects[i, j] && BoardObjects[i, j] is not Blank)
                {
                    Console.ResetColor();

                    (var x, var y) = Console.GetCursorPosition();

                    var oldPiecePos = _lastBoardObjects[i, j].Pos;
                    var newPiecePos = BoardObjects[i, j].Pos;

                    // Draws a blank on the old piece position
                    Console.SetCursorPosition(oldPiecePos.X * 3, oldPiecePos.Y);

                    Console.ForegroundColor = Colors.Square["Blank"];
                    Console.Write($" {Symbols.Square[SquareObject.Blank]} ");

                    // Draws the piece on the new position
                    Console.SetCursorPosition(newPiecePos.X * 3, newPiecePos.Y);

                    Console.ForegroundColor = BoardObjects[i, j].Color;
                    Console.Write($" {BoardObjects[i, j].Symbol} ");

                    Console.SetCursorPosition(x, y);

                    Array.Copy(BoardObjects, _lastBoardObjects, BoardObjects.Length);

                    Console.ResetColor();
                    return;
                }
            }
        }
    }
}
