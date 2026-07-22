using System;
using System.Collections.Generic;
using Chess.Engine.Bases;
using Chess.Settings;

namespace Chess.Scenes.Gameplay;

public sealed class OptionsRenderer : BaseRenderer
{
    public OptionsCursor Cursor { get; set; } = null!;

    private List<string> _lines = Locale.StringTable["Options"];

    public override void Start()
    {
        base.Start();
        IsFirstRender = true;
        Cursor.MaxIndex = _lines.Count;

        Locale.CurrentLanguageChanged += OnCurrentLanguageChanged;
    }

    private void OnCurrentLanguageChanged()
    {
        _lines = Locale.StringTable["Options"];
        FirstRender();
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

        var idx = 0;
        foreach (var line in _lines)
        {
            if (idx == Cursor.Pos.Y)
            {
                Console.Write("> ");
            }
            Console.WriteLine(line);
            idx++;
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

    public override void Finish()
    {
        base.Finish();
        IsFirstRender = true;
    }
}
