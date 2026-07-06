namespace Chess.Engine.Bases;

public abstract class BaseRenderer : BaseBehavior
{
    protected virtual bool IsFirstRender { get; set; } = true;
    protected abstract void FirstRender();
}
