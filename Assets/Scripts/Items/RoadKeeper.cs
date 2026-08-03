using System.Collections;
using Global;
using Mics;
using UnityEngine;

namespace Items
{
    public class RoadKeeper : ReusableItem
    {
        [SerializeField] private float speed = 5f;

        private Animation anim;
        private Anim animationClipManager;

        private void Awake()
        {
            animationClipManager = Anim.Instance;
            anim = GetComponent<Animation>();
            anim.clip = animationClipManager.idle;
        }

        public override void Spawn()
        {
            throw new System.NotImplementedException();
        }

        public override void Recycle()
        {
            throw new System.NotImplementedException();
        }

        public void PlayerCome(Vector3 position)
        {
            StartCoroutine(CorPlayerCome(position));
        }

        IEnumerator CorPlayerCome(Vector3 pos)
        {
            float timer = 0f;
            pos -= transform.position;
            pos.y = transform.position.y;
            while (true)
            {
                yield return null;
                if (pos.x > 0)
                {
                    anim.clip = animationClipManager.leftJump;
                }
                else if (pos.x < 0)
                {
                    anim.clip = animationClipManager.rightJump;
                }

                transform.Translate(-pos.normalized * (Time.deltaTime * speed));
                timer += Time.deltaTime;
                if (timer > 4f)
                {
                    break;
                }
            }
        }

        public void OnHitPlayer()
        {
        }
    }
}