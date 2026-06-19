using System.Collections.Generic;
using Chess.Engine.Bases;
using Chess.Scenes.Gameplay;

namespace Chess.Engine;

public sealed class GameState
{
    private readonly Start _start = new();
    private readonly Update _update = new();
    private readonly Finish _finish = new();

    private readonly List<BaseScene> _scenes = [];
    private readonly BaseScene? _currentScene;

    public GameState()
    {
        _scenes.Add(new Gameplay());

        _currentScene = _scenes[0];
    }

    public void Initialize()
    {
        while (_currentScene is not null)
        {
            _start.Behaviors = _currentScene.Behaviors;
            _start.Execute();

            _update.Behaviors = _currentScene.Behaviors;
            _update.Execute();

            _finish.Behaviors = _currentScene.Behaviors;
            _finish.Execute();
        }
    }
}
