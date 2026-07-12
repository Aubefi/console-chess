using Chess.Engine.Bases;

namespace Chess.Engine;

public sealed class Start : BaseState
{
    public override void Execute()
    {
        foreach (var behavior in Behaviors)
        {
            behavior.Start();
        }
    }
}
