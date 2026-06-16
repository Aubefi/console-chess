using System;
using System.Collections.Generic;

namespace Chess.Assets;

public static class Colors
{
    public static readonly ConsoleColor Default = ConsoleColor.Gray;

    public static readonly Dictionary<string, ConsoleColor> Cursor = new()
    {
        ["Default"] = ConsoleColor.DarkBlue,
        ["Error"] = ConsoleColor.DarkRed,
        ["PieceSelected"] = ConsoleColor.DarkYellow,
    };

    public static readonly Dictionary<string, ConsoleColor> Square = new()
    {
        ["Blank"] = ConsoleColor.White,
        ["BlankHover"] = ConsoleColor.Blue,
        ["AllowedMovement"] = ConsoleColor.Green
    };

    public static readonly Dictionary<string, ConsoleColor> Pieces = new()
    {
        ["Black"] = ConsoleColor.Red,
        ["BlackSelected"] = ConsoleColor.Black,
        ["White"] = ConsoleColor.White,
        ["WhiteSelected"] = ConsoleColor.White
    };
}
