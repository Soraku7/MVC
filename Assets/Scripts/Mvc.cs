using System;
using System.Collections.Generic;

public static class Mvc
{
    public static Dictionary<string, View> Views = new Dictionary<string, View>();
    public static Dictionary<string, Model> Models = new Dictionary<string, Model>();
    public static Dictionary<string, Type> Controllers = new Dictionary<string, Type>();

    public static void RegisterView(View view)
    {
        Views[view.Name] = view;
    }

    public static void RegisterModel(Model model)
    {
        Models[model.Name] = model;
    }

    public static void RegisterController(string eventName, Type type)
    {
        Controllers[eventName] = type;
    }

    public static T GetModel<T>() where T : Model
    {
        Model model = null;

        foreach (var item in Models.Values)
        {
            if (item is T)
            {
                model = item;
            }
        }

        if (model != null)
        {
            return (T)model;
        }

        return null;
    }

    public static T GetView<T>() where T : View
    {
        View view = null;
        foreach (var item in Views.Values)
        {
            if (item is T)
            {
                view = item;
            }
        }

        if (view != null)
        {
            return (T)view;
        }

        return null;
    }

    public static void SendEvent(string eventName, object data = null)
    {
        foreach (var item in Controllers.Keys)
        {
            if (item == eventName)
            {
                Type type = Controllers[eventName];
                Controller controller = (Controller)Activator.CreateInstance(type);
                controller.Execute();
            }
        }

        foreach (var view in Views.Values)
        {
            if (view.ContainEvent(eventName))
            {
                view.HandleEvent(data);
            }
        }
    }
}