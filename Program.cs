using System;
using Chess.Core;

namespace Chess;

public sealed class Program
{
    public static void Main()
    {
        Game game = new();

        game.Start();
        game.Update();

        Console.CursorVisible = true;
    }
}
