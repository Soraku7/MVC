using Global;
using Mics;
using UnityEngine;

namespace Items
{
    public class MultiplyItem : ResuableItem
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
                other.SendMessage("OnMultiplyCoin");
                OnHitPlayer();
            }
        }

        private void OnHitPlayer()
        {
            GameManager.Instance.objectPool.Recycle(gameObject);
            GameManager.Instance.sound.PlayEffectAudio("Se_UI_Props");
        }
    }
}