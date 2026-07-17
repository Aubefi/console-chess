using Chess.Engine.Bases;

namespace Chess.Engine;

public sealed class GameState
{
    private readonly Start _start = new();
    private readonly Update _update = new();
    private readonly Finish _finish = new();

    public void Initialize()
    {
        do
        {
            SetBehaviors(Tree.CurrentScene);

            _start.Execute();
            _update.Execute();
            _finish.Execute();
        }
        while (Tree.CurrentScene != Tree.Scenes["Exit"]);
    }

    private void SetBehaviors(BaseScene scene)
    {
        _start.Behaviors = scene.Behaviors;
        _update.Behaviors = scene.Behaviors;
        _finish.Behaviors = scene.Behaviors;
    }
}
