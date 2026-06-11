using System.Collections.Generic;

namespace Chess.Assets;

public enum PiecesEnum
{
    EmptySquare, Pawn, Bishop, Knight, Rook, Queen, King
}

public static class Symbols
{
    public static readonly Dictionary<PiecesEnum, char> BoardSymbols = new()
    {
        [PiecesEnum.EmptySquare] = '\u00B7',
        [PiecesEnum.Pawn] = '\u2659',
        [PiecesEnum.Bishop] = '\u2657',
        [PiecesEnum.Knight] = '\u2658',
        [PiecesEnum.Rook] = '\u2656',
        [PiecesEnum.Queen] = '\u2655',
        [PiecesEnum.King] = '\u2654'
    };
}
