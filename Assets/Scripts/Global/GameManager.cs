using Tools;

namespace Global
{
    public class GameManager : MonoScriptTon<GameManager>
    {
        public static Sound sound;

        public override void Awake()
        {
            sound = gameObject.AddComponent<Sound>();
            DontDestroyOnLoad(gameObject);
        }
    }
}