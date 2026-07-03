using System;
using Chess.Assets;
using Chess.Engine.Bases;
using Chess.GameObjects.ChessPieces;

namespace Chess.Scenes.Gameplay;

public class Board
{
    public readonly BaseUIObject[,] BoardObjects = new BaseUIObject[8, 8];

    public Board()
    {
        BuildBoardPieces();
    }

    private void BuildBoardPieces()
    {
        SquareObject[] piecesOrder = [
            SquareObject.Rook, SquareObject.Knight, SquareObject.Bishop, SquareObject.Queen,
            SquareObject.King, SquareObject.Bishop, SquareObject.Knight, SquareObject.Rook
        ];

        var symbols = Symbols.Square;

        for (var k = 0; k < 8; k++)
        {
            // Black pieces
            BoardObjects[0, k] = CreatePiece(piecesOrder[k], symbols[piecesOrder[k]], Colors.Pieces["Black"], k, 0);

            // Black pawns
            BoardObjects[1, k] = CreatePiece(SquareObject.Pawn, symbols[SquareObject.Pawn], Colors.Pieces["Black"], k, 1);
            SetPawnDirection(BoardObjects[1, k], PawnDirection.Black);

            // White pawns
            BoardObjects[6, k] = CreatePiece(SquareObject.Pawn, symbols[SquareObject.Pawn], Colors.Pieces["White"], k, 6);
            SetPawnDirection(BoardObjects[6, k], PawnDirection.White);

            // White pieces
            BoardObjects[7, k] = CreatePiece(piecesOrder[k], symbols[piecesOrder[k]], Colors.Pieces["White"], k, 7);
        }

        for (var i = 2; i < 6; i++)
        {
            for (var j = 0; j < 8; j++)
            {
                BoardObjects[i, j] = CreatePiece(
                    SquareObject.Blank, symbols[SquareObject.Blank], Colors.Square["Blank"], j, i
                );
            }
        }
    }

    private static BaseUIObject CreatePiece(SquareObject type, char symbol, ConsoleColor color, int x, int y)
    {
        return type switch
        {
            SquareObject.King => new King(symbol, color, x, y),
            SquareObject.Queen => new Queen(symbol, color, x, y),
            SquareObject.Rook => new Rook(symbol, color, x, y),
            SquareObject.Knight => new Knight(symbol, color, x, y),
            SquareObject.Bishop => new Bishop(symbol, color, x, y),
            SquareObject.Pawn => new Pawn(symbol, color, x, y),
            _ => new Blank(symbol, color, x, y)
        };
    }

    private static void SetPawnDirection(BaseUIObject square, PawnDirection direction)
    {
        if (square is Pawn pawn)
        {
            pawn.SetPawnDirection(direction);
        }
    }
}
