using Chess.Engine.Bases;
using Chess.Scenes.Gameplay;

namespace Chess.Engine;

public sealed class GameState
{
    private readonly Start _start;
    private readonly Update _update;
    private readonly Finish _finish;

    private readonly BaseScene _scene;

    public GameState()
    {
        _start = new();
        _update = new();
        _finish = new();

        _scene = new Gameplay();
    }

    public void Initialize()
    {
        while (_scene is not null)
        {
            _start.Behaviors = _scene.Behaviors;
            _start.Execute();

            _update.Behaviors = _scene.Behaviors;
            _update.Execute();

            _finish.Behaviors = _scene.Behaviors;
            _finish.Execute();
        }
    }
}
