using System;
using System.Collections.Generic;
using Chess.Engine;
using Chess.Engine.Localization;
using Chess.Settings;

namespace Chess;

public sealed class Game
{
    public static void Run()
    {
        SetConsoleSettings();

        Locale.StringTable = Json.OpenFile<Dictionary<string, List<string>>>("Settings/Locale", "en")
            ?? throw new InvalidOperationException("Could not acess file at ../Settings/Locale");

        new GameState().Initialize();

        ResetConsoleSettings();
    }

    private static void SetConsoleSettings()
    {
        Console.Clear();
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.CursorVisible = false;
    }

    private static void ResetConsoleSettings()
    {
        Console.Clear();
        Console.ResetColor();
        Console.CursorVisible = true;
    }
}
