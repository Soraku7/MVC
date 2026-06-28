public abstract class Model
{
    public abstract string Name { get; }

    public virtual void SendEvent(string name, object data = null)
    {
        Mvc.SendEvent(name, data);
    }
}