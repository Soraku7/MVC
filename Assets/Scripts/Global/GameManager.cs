using Mics;
using Tools;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Global
{
    [RequireComponent(typeof(Sound))]
    [RequireComponent(typeof(ObjectPool))]
    public class GameManager : MonoScriptTon<GameManager>
    {
        public Sound sound;
        private ObjectPool objectPool;

        public override void Awake()
        {
            sound = gameObject.AddComponent<Sound>();
            objectPool = GetComponent<ObjectPool>();

            Mvc.RegisterController(Consts.E_EnterScene, typeof(EnterSceneController));
            SceneArgs args = new SceneArgs() { sceneIndex = 0 };
            SendEvent(Consts.E_ExitScene, args);

            DontDestroyOnLoad(gameObject);
            LoadScene(4);
        }

        public void LoadScene(int buildIndex)
        {
            SceneArgs args = new SceneArgs();
            args.sceneIndex = SceneManager.GetActiveScene().buildIndex;
            SendEvent(Consts.E_ExitScene, args);

            SceneManager.LoadScene(buildIndex, LoadSceneMode.Single);

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