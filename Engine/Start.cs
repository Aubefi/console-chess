using System.Collections.Generic;
using Chess.Engine.Bases;

namespace Chess.Engine;

public sealed class Start : BaseState
{
    public override List<BaseBehavior> Behaviors { get; set; } = [];

    public override void Execute()
    {
        foreach (var behavior in Behaviors)
        {
            behavior.Start();
        }
    }
}
