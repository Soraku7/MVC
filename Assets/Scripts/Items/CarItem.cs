using System.Collections;
using Global;
using Mics;
using UnityEngine;

namespace Items
{
    public class CarItem : ResuableItem
    {
        private float speed = 10;

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
                Time.timeScale = 0;
            }
        }

        public void OnEngine()
        {
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
    }
}