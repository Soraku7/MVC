using UnityEngine;

namespace Global
{
    public abstract class ResuableItem : MonoBehaviour, IResuable
    {
        public abstract void Spawn();

        public abstract void Recycle();
    }
}