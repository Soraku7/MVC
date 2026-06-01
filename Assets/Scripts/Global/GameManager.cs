using Mics;
using Tools;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Global
{
    [RequireComponent(typeof(Sound))]
    public class GameManager : MonoScriptTon<GameManager>
    {
        public Sound sound;

        public override void Awake()
        {
            sound = gameObject.AddComponent<Sound>();
            DontDestroyOnLoad(gameObject);
            LoadScene(4);
        }

        public void LoadScene(int buildIndex)
        {
            if (buildIndex == 0)
            {
                Mvc.RegisterController(Consts.E_EnterScene, typeof(EnterSceneController));
            }
            else
            {
                SceneArgs args = new SceneArgs();
                args.sceneIndex = SceneManager.GetActiveScene().buildIndex;
                SendEvent(Consts.E_ExitScene, args);

                SceneManager.LoadScene(buildIndex, LoadSceneMode.Single);
            }

            SceneManager.sceneLoaded += (scene, mode) =>
            {
                SceneArgs enterArg = new SceneArgs() { sceneIndex = scene.buildIndex };
                SendEvent(Consts.E_EnterScene, enterArg);
            };
        }

        public void SendEvent(string eventName, object data = null)
        {
            Mvc.SendEvent(eventName, data);
        }
    }
}