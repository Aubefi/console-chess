using System;
using Chess.Engine;

namespace Chess;

public sealed class Game
{
    private readonly GameState _gameState;

    public Game()
    {
        _gameState = new();

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
