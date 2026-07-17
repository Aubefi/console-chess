using System;
using Chess.Engine;

namespace Chess;

public sealed class Game
{
    public Game()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.Clear();
        Console.CursorVisible = false;
    }

    public static void Run()
    {
        new GameState().Initialize();

        Console.Clear();
        Console.ResetColor();
        Console.CursorVisible = true;
    }
}
