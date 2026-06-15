using System.Collections.Generic;

namespace Chess.Engine.Bases;

public abstract class BaseState
{
    public abstract List<BaseBehavior> Behaviors { get; set; }

    public abstract void Execute();
}
