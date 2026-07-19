using System;
using Global;
using Items;
using Mics;
using UnityEngine;

public class CoinItem : Item
{
    private bool _isArea;
    private Player _player;

    float _moveSpeed = 30f;

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

            transform.Translate(
                (_player.transform.position - transform.position).normalized * (Time.deltaTime * _moveSpeed),
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