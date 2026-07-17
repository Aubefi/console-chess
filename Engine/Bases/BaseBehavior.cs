namespace Chess.Engine.Bases;

// Just like MonoBehavior from Unity, BaseBehavior gives its children classes
// a way to acess the game's base states for:
//
// - dependencies initialization;
// - take part in the current scene loop;
// - be taken care of at the scene wrap-up.
//
//
// Every new BaseBehavior class needs to be accounted in the scene's behaviors
// list inside the InitializeBehaviors method and also receive its dependecies
// in the InitializeDependencies method.
public abstract class BaseBehavior
{
    public virtual void Start() { }
    public virtual void Update() { }
    public virtual void Finish() { }
}
