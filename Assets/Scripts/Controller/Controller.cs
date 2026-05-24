using UnityEngine;

public abstract class Controller
{
    public abstract void Execute(object data = null);

    public T GetModel<T>() where T : Model
    {
        return Mvc.GetModel<T>();
    }

    public T GetView<T>() where T : View
    {
        return Mvc.GetView<T>();
    }

    public void RegisterController(string eventName, System.Type type)
    {
        Mvc.RegisterController(eventName, type);
    }

    public void RegisterView(View view)
    {
        Mvc.RegisterView(view);
    }

    public void RegisterModel(Model model)
    {
        Mvc.RegisterModel(model);
    }
}