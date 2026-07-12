using Chess.Engine.Bases;

namespace Chess.Engine;

public sealed class Finish : BaseState
{
    public override void Execute()
    {
        foreach (var behavior in Behaviors)
        {
            behavior.Finish();
        }
    }
}
