using System.Collections.Generic;

namespace Chess.Assets;

public enum SquareObject
{
    Blank, Pawn, Bishop, Knight, Rook, Queen, King
}

public static class Symbols
{
    public static readonly Dictionary<SquareObject, char> Square = new()
    {
        [SquareObject.Blank] = '\u00B7',
        [SquareObject.Pawn] = '\u2659',
        [SquareObject.Bishop] = '\u2657',
        [SquareObject.Knight] = '\u2658',
        [SquareObject.Rook] = '\u2656',
        [SquareObject.Queen] = '\u2655',
        [SquareObject.King] = '\u2654'
    };
}
