using System;
using Chess.Models;
using Chess.UI;

namespace Chess.Core;

public sealed class Game()
{
    private readonly Board _board = new();
    private readonly Cursor _cursor = new(' ', ConsoleColor.Gray, 0, 0);

    public void Start()
    {
        ConfigureConsole();

        _board.BuildBaseGridObjects();
    }

    public void Update()
    {
        while (true)
        {
            _board.DisplayGridObjects(_cursor);
            BoardNavigation.ReadPlayerInput(_board, _cursor);
        }
    }

    private static void ConfigureConsole()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.CursorVisible = false;
        Console.Clear();
    }
}
