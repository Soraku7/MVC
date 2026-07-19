using Global;
using Mics;
using UnityEngine;

namespace Items
{
    public class MagnetItem : Item
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
            if (other.CompareTag("Player"))
            {
                other.SendMessage("OnMagnet");
                OnHitPlayer();
            }
        }

        private void OnHitPlayer()
        {
            GameManager.Instance.sound.PlayEffectAudio(Consts.Se_UI_Magnet);
            GameManager.Instance.objectPool.Recycle(gameObject);
        }
    }
}