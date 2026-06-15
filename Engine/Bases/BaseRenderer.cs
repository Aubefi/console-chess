namespace Chess.Engine.Bases;

public abstract class BaseRenderer
{
    protected virtual bool IsFirstRender { get; set; }

    public abstract void Render();
    public abstract void FirstRender();
}
