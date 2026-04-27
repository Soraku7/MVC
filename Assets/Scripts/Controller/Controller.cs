using UnityEngine;

    public abstract class Controller : MonoBehaviour
    {
        public abstract void Execute();
        public T GetModel<T>()  where T : Model
        {
            return Mvc.GetModel<T>();
        }

        public T GetView<T>() where T : View
        {
            return  Mvc.GetView<T>();
        }
    }