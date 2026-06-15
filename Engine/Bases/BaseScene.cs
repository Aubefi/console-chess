using System.Collections.Generic;

namespace Chess.Engine.Bases;

public abstract class BaseScene
{
    public abstract List<BaseBehavior> Behaviors { get; protected set; }

    protected abstract void InitializeBehaviors();
    protected abstract void InitializeDependencies();
}
