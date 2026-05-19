using UnityEngine;

namespace Tools
{
    public class MonoScriptTon<T> : MonoBehaviour where T : MonoScriptTon<T>
    {
        private static T _instance;

        public static T Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = FindObjectOfType<T>();
                }

                return _instance;
            }
        }

        public virtual void Awake()
        {
            _instance = this as T;
        }
    }
}