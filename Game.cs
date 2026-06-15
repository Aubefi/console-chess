using System;
using Chess.Engine;

namespace Chess;

public sealed class Game
{
    private readonly GameState _gameState;

    private readonly string _originalTitle = string.Empty;

    public Game()
    {
        _gameState = new();

        if (OperatingSystem.IsWindows())
        {
            _originalTitle = Console.Title;
            Console.Title = "Console Chess";
        }

        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.Clear();
        Console.CursorVisible = false;
    }

    public void Run()
    {
        _gameState.Initialize();

        if (OperatingSystem.IsWindows())
        {
            Console.Title = _originalTitle;
        }

        Console.Clear();
        Console.CursorVisible = true;
    }
}
