using System.Collections.Generic;

namespace Chess.Assets;

public enum PiecesEnum
{
    EmptySquare, Pawn, Bishop, Knight, Rook, Queen, King
}

public static class Symbols
{
    // public static readonly Dictionary<PiecesEnum, char> WhiteSymbols = new()
    // {
    //     [PiecesEnum.Pawn] = 'P',
    //     [PiecesEnum.Bishop] = 'B',
    //     [PiecesEnum.Knight] = 'N',
    //     [PiecesEnum.Rook] = 'R',
    //     [PiecesEnum.Queen] = 'Q',
    //     [PiecesEnum.King] = 'K'
    // };

    // public static readonly Dictionary<PiecesEnum, char> BlackSymbols = new()
    // {
    //     [PiecesEnum.Pawn] = 'p',
    //     [PiecesEnum.Bishop] = 'b',
    //     [PiecesEnum.Knight] = 'n',
    //     [PiecesEnum.Rook] = 'r',
    //     [PiecesEnum.Queen] = 'q',
    //     [PiecesEnum.King] = 'k'
    // };

    public static readonly Dictionary<PiecesEnum, char> WhiteSymbols = new()
    {
        [PiecesEnum.Pawn] = '\u2659',
        [PiecesEnum.Bishop] = '\u2657',
        [PiecesEnum.Knight] = '\u2658',
        [PiecesEnum.Rook] = '\u2656',
        [PiecesEnum.Queen] = '\u2655',
        [PiecesEnum.King] = '\u2654'
    };

    public static readonly Dictionary<PiecesEnum, char> BlackSymbols = new()
    {
        // [PiecesEnum.Pawn] = '\u265F',
        // [PiecesEnum.Bishop] = '\u265D',
        // [PiecesEnum.Knight] = '\u265E',
        // [PiecesEnum.Rook] = '\u265C',
        // [PiecesEnum.Queen] = '\u265B',
        // [PiecesEnum.King] = '\u265A'
        [PiecesEnum.Pawn] = '\u2659',
        [PiecesEnum.Bishop] = '\u2657',
        [PiecesEnum.Knight] = '\u2658',
        [PiecesEnum.Rook] = '\u2656',
        [PiecesEnum.Queen] = '\u2655',
        [PiecesEnum.King] = '\u2654'
    };
}
