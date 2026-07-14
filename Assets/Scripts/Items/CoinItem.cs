using System;
using Global;
using Mics;
using UnityEngine;

public class CoinItem : ReusableItem
{
    private bool _isArea;
    private Player _player;

    private GameModel gm;

    private void Start()
    {
        _player = Mvc.GetView<Player>();
        gm = Mvc.GetModel<GameModel>();
    }

    private void Update()
    {
        Debug.Log(_isArea);
        Debug.Log(gm.IsMegnet);
        if (gm.IsMegnet && _isArea && _player != null)
        {
            Debug.Log("BB");
            transform.Translate((_player.transform.position - transform.position).normalized * (Time.deltaTime * 10f),
                Space.World);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag(Tags.Player))
        {
            GameManager.Instance.sound.PlayEffectAudio(Consts.Se_UI_JinBi);
            other.SendMessage("PickCoin");
            GameManager.Instance.objectPool.Recycle(gameObject);
        }
        else if (other.CompareTag(Tags.MagnetTrigger))
        {
            Debug.Log("AA");
            AcrossPlayer();
        }
    }

    private void AcrossPlayer()
    {
        _isArea = true;
    }

    public override void Spawn()
    {
        _isArea = false;
    }

    public override void Recycle()
    {
        StopAllCoroutines();
        _isArea = false;
    }
}