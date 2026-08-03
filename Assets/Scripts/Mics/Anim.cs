using UnityEngine;

namespace Mics
{
    [System.Serializable]
    public class Anim
    {
        private static Anim _instance;
        private static object syncRoot;
        public AnimationClip idle;
        public AnimationClip rightJump;
        public AnimationClip leftJump;

        public static Anim Instance
        {
            get
            {
                lock (syncRoot)
                {
                    if (_instance == null)
                    {
                        _instance = new Anim();
                    }

                    return _instance;
                }
            }
            set => _instance = value;
        }
    }
}