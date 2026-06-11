using System;
using Chess.Assets;
using Chess.Engine;
using Chess.Graphics;
using Chess.Objects;

namespace Chess.UI;

public class Board : BaseBehavior
{
    private BoardRenderer? _boardRenderer;

    public BaseUIObject[,] GridObjects = new BaseUIObject[8, 8];
    public required Cursor BoardCursor;

    public override void Start()
    {
        BuildBaseGridObjects();

        _boardRenderer = new BoardRenderer { GridObjects = GridObjects, Cursor = BoardCursor };
    }

    public override void Update()
    {
        _boardRenderer?.RenderBoard();
    }

    public BaseUIObject GetPieceByCoordinates(Position pos)
        => GridObjects[pos.Y, pos.X];

    private void BuildBaseGridObjects()
    {
        PiecesEnum[] backOrder = [
            PiecesEnum.Rook, PiecesEnum.Knight, PiecesEnum.Bishop, PiecesEnum.Queen,
            PiecesEnum.King, PiecesEnum.Bishop, PiecesEnum.Knight, PiecesEnum.Rook];

        var symbols = Symbols.BoardSymbols;

        for (byte i = 0; i < 8; i++)
        {
            // Black pieces
            GridObjects[0, i] = CreatePiece(backOrder[i], symbols[backOrder[i]], ConsoleColor.Gray, i, 0);

            // Black pawns
            GridObjects[1, i] = CreatePiece(PiecesEnum.Pawn, symbols[PiecesEnum.Pawn], ConsoleColor.Gray, i, 1);

            // White pawns
            GridObjects[6, i] = CreatePiece(PiecesEnum.Pawn, symbols[PiecesEnum.Pawn], ConsoleColor.White, i, 6);

            // White pieces
            GridObjects[7, i] = CreatePiece(backOrder[i], symbols[backOrder[i]], ConsoleColor.White, i, 7);
        }

        for (byte i = 2; i < 6; i++)
        {
            for (byte j = 0; j < 8; j++)
            {
                GridObjects[i, j] ??=
                    CreatePiece(PiecesEnum.EmptySquare, symbols[PiecesEnum.EmptySquare], ConsoleColor.White, j, i);
            }
        }
    }

    private static BaseUIObject CreatePiece(PiecesEnum type, char symbol, ConsoleColor color, byte x, byte y)
    {
        return type switch
        {
            PiecesEnum.King => new King(symbol, color, x, y),
            PiecesEnum.Queen => new Queen(symbol, color, x, y),
            PiecesEnum.Rook => new Rook(symbol, color, x, y),
            PiecesEnum.Knight => new Knight(symbol, color, x, y),
            PiecesEnum.Bishop => new Bishop(symbol, color, x, y),
            PiecesEnum.Pawn => new Pawn(symbol, color, x, y),
            _ => new EmptySquare(symbol, color, x, y)
        };
    }
}
