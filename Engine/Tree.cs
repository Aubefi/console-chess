using System;
using System.Collections.Generic;
using Chess.Engine.Bases;
using Chess.Scenes.Exit;
using Chess.Scenes.Gameplay;
using Chess.Scenes.Options;
using Chess.Scenes.Title;

namespace Chess.Engine;

public sealed class Tree
{
    public static event Action<BaseScene>? CurrentSceneChanged;

    public static Dictionary<string, BaseScene> Scenes { get; private set; } = new()
    {
        ["Title"] = new Title(),
        ["Options"] = new Options(),
        ["Gameplay"] = new Gameplay(),
        ["Exit"] = new Exit()
    };

    public static BaseScene CurrentScene { get; private set; } = Scenes["Title"];
    public static void ChangeSceneTo(BaseScene scene)
    {
        CurrentScene = scene;
        CurrentSceneChanged?.Invoke(CurrentScene);
    }
}
