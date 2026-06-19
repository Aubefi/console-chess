namespace Chess.Engine.Bases;

public abstract class BaseRenderer : BaseBehavior
{
    protected abstract bool IsFirstRender { get; set; }
    protected abstract void FirstRender();
}
