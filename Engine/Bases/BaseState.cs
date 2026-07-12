using System.Collections.Generic;

namespace Chess.Engine.Bases;

public abstract class BaseState
{
    public virtual List<BaseBehavior> Behaviors { get; set; } = [];

    public abstract void Execute();
}
