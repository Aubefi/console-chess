using System.Collections.Generic;

namespace Chess.Engine;

public sealed class Update : BaseObject
{
    public required List<BaseBehavior> BaseBehaviors { get; init; }

    public override void Run()
    {
        while (true)
        {
            foreach (var behavior in BaseBehaviors)
            {
                behavior.Update();
            }
        }
    }
}
