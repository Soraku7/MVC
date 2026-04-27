using System.Collections.Generic;
using UnityEngine;

public abstract class View : MonoBehaviour
{
    public abstract string Name { get; }
    public List<string> attractEventList = new List<string>();

    public virtual void RegisterViewEvent()
    {
    }

    public virtual void SendEvent(string eventName, object data = null)
    {
        Mvc.SendEvent(eventName, data);
    }

    public abstract void HandleEvent(object data = null);

    public T GetModel<T>() where T : Model
    {
        return Mvc.GetModel<T>();
    }

    public bool ContainEvent(string eventName)
    {
        foreach (var item in attractEventList)
        {
            if (item == eventName)
            {
                return true;
            }
        }

        return false;
    }
}