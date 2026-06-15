using System.Collections.Generic;
using Chess.Engine.Bases;

namespace Chess.Engine;

public sealed class Update : BaseState
{
    public override List<BaseBehavior> Behaviors { get; set; } = [];

    public override void Execute()
    {
        while (true)
        {
            foreach (var behavior in Behaviors)
            {
                behavior.Update();
            }
        }
    }
}
