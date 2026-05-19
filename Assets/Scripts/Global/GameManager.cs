using System;
using Unity.VisualScripting;
using UnityEngine;

namespace Global
{
    public class GameManager : MonoBehaviour
    {
        public static Sound sound;

        private void Awake()
        {
            sound = gameObject.AddComponent<Sound>();
            DontDestroyOnLoad(gameObject);
        }
    }
}