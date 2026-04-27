using UnityEngine;

    public abstract class Model : MonoBehaviour
    {
        public abstract string Name { get; }

        public virtual void SendEvent(string name , object data = null)
        {
            Mvc.SendEvent(name, data);
        }
    }