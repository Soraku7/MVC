using UnityEngine;

namespace Global
{
    public abstract class ResuableItem : MonoBehaviour, IResuable
    {
        public int angular = 180;

        public abstract void Spawn();

        public abstract void Recycle();

        protected virtual void LateUpdate()
        {
            transform.Rotate(Vector3.up * (angular * Time.deltaTime));
        }
    }
}