using Chess.Engine.Bases;

namespace Chess.Engine;

public sealed class Update : BaseState
{
    private bool _exitCurrentSceneUpdate = false;

    public Update()
    {
        Tree.CurrentSceneChanged += (_) => _exitCurrentSceneUpdate = true;
    }

    public override void Execute()
    {
        _exitCurrentSceneUpdate = false;

        while (_exitCurrentSceneUpdate is false)
        {
            foreach (var behavior in Behaviors)
            {
                behavior.Update();

                if (_exitCurrentSceneUpdate is true)
                {
                    break;
                }
            }
        }
    }
}
