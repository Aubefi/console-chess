using System;
using System.Collections.Generic;
using Chess.Engine.Bases;
using Chess.Settings;

namespace Chess.Scenes.Gameplay;

public sealed class TitleRenderer : BaseRenderer
{
    public TitleCursor Cursor { get; set; } = null!;

    private readonly List<string> _lines = Locale.StringTable["Title"];

    public override void Start()
    {
        base.Start();
        IsFirstRender = true;
    }

    public override void Update()
    {
        if (IsFirstRender)
        {
            FirstRender();
            return;
        }

        if (Cursor.HasMoved)
        {
            ClearLastCursorPosition();
            DisplayNewCursorPosition();

            Cursor.SetPosition(new(Cursor.Pos.X, Cursor.Pos.Y));
        }
    }

    protected override void FirstRender()
    {
        Console.Clear();
        Console.ResetColor();

        Console.Write("> ");
        foreach (var line in _lines)
        {
            Console.WriteLine(line);
        }

        IsFirstRender = false;
    }

    private void ClearLastCursorPosition()
    {
        var (x, y) = (Cursor.LastPosition.X, Cursor.LastPosition.Y);
        Console.SetCursorPosition(x, y);

        var lineLength = _lines[y].Length + 2;
        Console.Write(new string(' ', lineLength));

        Console.SetCursorPosition(x, y);
        Console.Write(_lines[y]);
    }

    private void DisplayNewCursorPosition()
    {
        var (x, y) = (Cursor.Pos.X, Cursor.Pos.Y);
        Console.SetCursorPosition(x, y);

        Console.Write($"> {_lines[y]}");
    }
}
