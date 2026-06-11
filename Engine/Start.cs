using System;
using System.Collections.Generic;

namespace Chess.Engine;

public sealed class Start : BaseObject
{
    public required List<BaseBehavior> BaseBehaviors { get; init; }

    public override void Run()
    {
        ConfigureConsole();

        foreach (var behavior in BaseBehaviors)
        {
            behavior.Start();
        }
    }

    private static void ConfigureConsole()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Console.CursorVisible = false;
        Console.Clear();
    }
}
