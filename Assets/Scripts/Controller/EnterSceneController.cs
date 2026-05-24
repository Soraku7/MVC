using Mics;

public class EnterSceneController : Controller
{
    public override void Execute(object data = null)
    {
        if (data is SceneArgs)
        {
            SceneArgs args = (SceneArgs)data;
            switch (args.sceneIndex)
            {
                case 0:
                    Mvc.RegisterController(Consts.E_ExitScene, typeof(ExitSceneController));
                    break;

                default:
                    break;
            }
        }
    }
}