using Mics;
using UnityEngine;

namespace Player
{
    public class Player : View
    {
        private CharacterController _characterController;
        private float _runSpeed = 10;
        private Vector2 touchPos;
        private float maxSqrDistance = 225;

        private void Awake()
        {
            _characterController = GetComponent<CharacterController>();
        }

        public void FixedUpdate()
        {
            _characterController.Move(_runSpeed * Time.deltaTime * transform.forward);
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                touchPos = Input.mousePosition;
            }
            else if (Input.GetMouseButton(0))
            {
                Vector2 finPos = Input.mousePosition;
                Vector2 dir = finPos - touchPos;
                if (dir.sqrMagnitude > maxSqrDistance)
                {
                    if (dir.x > dir.y)
                    {
                        if (dir.x > 0)
                        {
                            //右
                        }
                        else if (dir.x < 0)
                        {
                            //左
                        }
                    }
                    else if (dir.x < dir.y)
                    {
                        if (dir.y > 0)
                        {
                            //上
                        }
                        else if (dir.y < 0)
                        {
                            //下
                        }
                    }
                }
            }
        }

        public override string Name => Consts.V_Player;

        public override void HandleEvent(object data = null)
        {
            throw new System.NotImplementedException();
        }
    }
}