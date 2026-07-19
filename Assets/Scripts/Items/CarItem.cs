using System.Collections;
using Global;
using Mics;
using UnityEngine;

namespace Items
{
    public class CarItem : Obstacle
    {
        private float speed = 10;
        public bool isMove = false;

        public override void Spawn()
        {
            throw new System.NotImplementedException();
        }

        public override void Recycle()
        {
            throw new System.NotImplementedException();
        }

        public void OnEngine()
        {
            if (isMove)
                StartCoroutine(OnMove());
        }

        IEnumerator OnMove()
        {
            while (true)
            {
                transform.Translate(speed * Time.deltaTime * Vector3.forward);
                yield return 0;
            }
        }

        protected override void OnHitPlayer()
        {
            Destroy(gameObject);
        }
    }
}