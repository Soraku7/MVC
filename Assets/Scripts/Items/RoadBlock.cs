using Global;
using Mics;
using UnityEngine;

namespace Items
{
    public class RoadBlock : ReusableItem
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
                OnHitPlayer();
                other.SendMessage("OnHitRoadBlock");
            }
        }

        private void OnHitPlayer()
        {
            GameManager.Instance.sound.PlayEffectAudio(Consts.Se_UI_Hit);
        }
    }
}