using System.Collections.Generic;

namespace Chess.Engine;

public sealed class Finish : BaseObject
{
    public required List<BaseBehavior> BaseBehaviors { get; init; }

    public override void Run()
    {
        foreach (var behavior in BaseBehaviors)
        {
            behavior.Finish();
        }
    }
}
