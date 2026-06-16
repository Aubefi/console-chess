using System;
using System.Collections.Generic;

namespace Chess.Assets;

public static class Colors
{
    public static readonly Dictionary<string, ConsoleColor> Default = new()
    {
        ["Black"] = ConsoleColor.Black,
        ["Gray"] = ConsoleColor.Gray,
        ["White"] = ConsoleColor.White
    };

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
        ["AllowedSquare"] = ConsoleColor.Green,
        ["AllowedMovement"] = ConsoleColor.DarkGreen
    };

    public static readonly Dictionary<string, ConsoleColor> Pieces = new()
    {
        ["Black"] = ConsoleColor.Red,
        ["BlackSelected"] = ConsoleColor.Black,
        ["White"] = ConsoleColor.White,
        ["WhiteSelected"] = ConsoleColor.White
    };
}
