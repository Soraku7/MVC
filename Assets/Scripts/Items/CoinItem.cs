using Global;
using Mics;
using UnityEngine;

public class CoinItem : ResuableItem
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(Tags.Player))
        {
            GameManager.Instance.sound.PlayEffectAudio(Consts.Se_UI_JinBi);
            other.SendMessage("PickCoin");
            GameManager.Instance.objectPool.Recycle(gameObject);
        }
    }

    public override void Spawn()
    {
        throw new System.NotImplementedException();
    }

    public override void Recycle()
    {
        throw new System.NotImplementedException();
    }
}