using System;
using Chess.Assets;
using Chess.Objects;

namespace Chess.UI;

public class Board
{
    public BaseUIObject[,] GridObjects = new BaseUIObject[8, 8];



    public BaseUIObject GetPieceByCoordinates(Position pos)
        => GridObjects[pos.X, pos.Y];

    private void BuildBaseGridObjects()
    {
        PiecesEnum[] backOrder = [
            PiecesEnum.Rook, PiecesEnum.Knight, PiecesEnum.Bishop, PiecesEnum.Queen,
            PiecesEnum.King, PiecesEnum.Bishop, PiecesEnum.Knight, PiecesEnum.Rook];

        for (byte i = 0; i < 8; i++)
        {
            // Black pieces
            GridObjects[0, i] = CreatePiece(backOrder[i], Symbols.BlackSymbols[backOrder[i]], ConsoleColor.Gray, 0, i);

            // Black pawns
            GridObjects[1, i] = CreatePiece(PiecesEnum.Pawn, Symbols.BlackSymbols[PiecesEnum.Pawn], ConsoleColor.Gray, 1, i);

            // White pawns
            GridObjects[6, i] = CreatePiece(PiecesEnum.Pawn, Symbols.WhiteSymbols[PiecesEnum.Pawn], ConsoleColor.White, 6, i);

            // White pieces
            GridObjects[7, i] = CreatePiece(backOrder[i], Symbols.WhiteSymbols[backOrder[i]], ConsoleColor.White, 7, i);
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
            _ => new Pawn(symbol, color, x, y)
        };
    }

    public BaseUIObject GetPieceByCoordinates(Position pos)
    {
        return GridObjects[pos.X, pos.Y];
    }
}
