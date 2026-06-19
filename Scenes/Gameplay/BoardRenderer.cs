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
    private readonly List<Position> _activeLegalMoves = [];

    private Position _lastCursorPos = new(0, 0);
    private bool _wasHoldingChessPiece = false;

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

            ClearLastCursorPosition();
            DisplayNewCursorPosition();
            DisplayLegalMoves();
            HideLegalMoves();
            UpdatePiecesPosition();
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
        for (var i = 0; i < 8; i++)
        {
            for (var j = 0; j < 8; j++)
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

        for (var i = 0; i < 8; i++)
        {
            for (var j = 0; j < 8; j++)
            {
                if ((j == Cursor.Pos.X) && (i == Cursor.Pos.Y) && Cursor.BackgroundColor is ConsoleColor color)
                {
                    Console.BackgroundColor = color;
                    Console.Write($" {BoardObjects[i, j].Symbol} ");
                    Console.ResetColor();

                    continue;
                }

                Console.ForegroundColor = BoardObjects[i, j].Color;
                Console.Write($" {BoardObjects[i, j].Symbol} ");
            }

            Console.Write("\n");
        }

        IsFirstRender = false;
        _lastCursorPos = Cursor.Pos;

        Console.ResetColor();
    }

    private void ClearLastCursorPosition()
    {
        if (Cursor.Pos == _lastCursorPos)
        {
            return;
        }

        Console.ResetColor();

        Console.SetCursorPosition(_lastCursorPos.X * 3, _lastCursorPos.Y);

        var square = BoardObjects[_lastCursorPos.Y, _lastCursorPos.X];

        Console.ForegroundColor = square.Color;
        Console.Write($" {square.Symbol} ");

        Console.ResetColor();
    }

    private void DisplayNewCursorPosition()
    {
        if (Cursor.Pos == _lastCursorPos)
        {
            return;
        }

        Console.ResetColor();

        Console.SetCursorPosition(Cursor.Pos.X * 3, Cursor.Pos.Y);

        if (Cursor.BackgroundColor is ConsoleColor color)
        {
            Console.BackgroundColor = color;
        }

        var square = BoardObjects[Cursor.Pos.Y, Cursor.Pos.X];

        Console.ForegroundColor = square is Blank || Cursor.IsHoldingChessPiece
            ? Cursor.Color
            : square.Color;

        // Cursor.Symbol being char.MinValue means he is NOT holding a chess piece
        var symbol = Cursor.Symbol is char.MinValue
            ? square.Symbol
            : Cursor.Symbol;

        Console.Write($" {symbol} ");

        Console.ResetColor();
    }

    private void HideLegalMoves()
    {
        if (Cursor.IsHoldingChessPiece || _activeLegalMoves.Count == 0)
        {
            return;
        }

        (int x, int y) = Console.GetCursorPosition();

        foreach (var pos in _activeLegalMoves)
        {
            var square = BoardObjects[pos.Y, pos.X];
            Console.SetCursorPosition(square.Pos.X * 3, square.Pos.Y);

            Console.ForegroundColor = square.Color;
            Console.Write($" {square.Symbol} ");
        }

        _activeLegalMoves.Clear();

        Console.SetCursorPosition(x, y);
        Console.ResetColor();
    }

    private void DisplayLegalMoves()
    {
        if (!Cursor.IsHoldingChessPiece)
        {
            return;
        }

        (int x, int y) = Console.GetCursorPosition();

        _activeLegalMoves.Clear();

        foreach (var square in BoardObjects)
        {
            if (square.BackgroundColor is not ConsoleColor color)
            {
                continue;
            }

            Console.SetCursorPosition(square.Pos.X * 3, square.Pos.Y);

            // Cursor is above THIS highlighted square
            if (square.Pos == Cursor.Pos)
            {
                Console.BackgroundColor = Colors.Square["AllowedMovement"];
                Console.ForegroundColor = Colors.Default["White"];
                Console.Write($" {Cursor.Symbol} ");
            }
            else
            {
                Console.BackgroundColor = color;
                Console.ForegroundColor = Colors.Default["Black"];
                Console.Write($" {square.Symbol} ");
            }

            _activeLegalMoves.Add(new(square.Pos.X, square.Pos.Y));
        }

        Console.SetCursorPosition(x, y);
        Console.ResetColor();
    }

    private void UpdatePiecesPosition()
    {
        for (var i = 0; i < 8; i++)
        {
            for (var j = 0; j < 8; j++)
            {
                if (BoardObjects[i, j] == _lastBoardObjects[i, j] || BoardObjects[i, j] is Blank)
                {
                    continue;
                }

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

                Array.Copy(BoardObjects, _lastBoardObjects, BoardObjects.Length);

                Console.SetCursorPosition(x, y);
                Console.ResetColor();

                return;
            }
        }
    }
}
