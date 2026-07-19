using Global;
using Mics;
using UnityEngine;

namespace Items
{
    public abstract class Obstacle : ReusableItem
    {
        protected virtual void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag(Tags.Player))
            {
                OnHitPlayer();
                other.SendMessage("OnHitObstacle");
            }
        }

        protected abstract void OnHitPlayer();
    }
}