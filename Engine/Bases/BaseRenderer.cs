namespace Chess.Engine.Bases;

public abstract class BaseRenderer : BaseBehavior
{
    protected virtual bool IsFirstRender { get; set; } = true;
    protected abstract void FirstRender();

    public override void Start()
    {
        Input.RedrawScene += FirstRender;
    }

    public override void Finish()
    {
        Input.RedrawScene -= FirstRender;
    }
}
