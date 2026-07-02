using Global;
using Mics;
using UnityEngine;

namespace Items
{
    public class Obstacle : ResuableItem
    {
        public override void Spawn()
        {
            throw new System.NotImplementedException();
        }

        public override void Recycle()
        {
            throw new System.NotImplementedException();
        }

        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag(Tags.Player))
            {
                OnHitPlayer();
                other.SendMessage("OnHitObstacle");
            }
        }

        private void OnHitPlayer()
        {
            GameManager.Instance.objectPool.Recycle(gameObject);
        }
    }
}