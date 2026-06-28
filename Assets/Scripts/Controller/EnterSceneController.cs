using Mics;
using UnityEngine;

public class EnterSceneController : Controller
{
    public override void Execute(object data = null)
    {
        if (data is SceneArgs)
        {
            SceneArgs args = (SceneArgs)data;
            switch (args.sceneIndex)
            {
                case 4:
                    Mvc.RegisterController(Consts.E_ExitScene, typeof(ExitSceneController));
                    RegisterModel(new GameModel());
                    RegisterView(GameObject.FindWithTag(Tags.Player).GetComponent<Player>());
                    break;

                default:
                    break;
            }
        }
    }
}