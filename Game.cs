using System;
using Chess.Engine;

namespace Chess;

public sealed class Game
{
    private readonly GameState _gameState = new();

    public Game()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.Clear();
        Console.CursorVisible = false;
    }

    public void Run()
    {
        _gameState.Initialize();

        Console.Clear();
        Console.CursorVisible = true;
    }
}
