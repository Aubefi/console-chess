namespace Chess.Engine.Bases;

public abstract class BaseRenderer : BaseBehavior
{
    protected virtual bool IsFirstRender { get; set; }
    public abstract void FirstRender();
}
