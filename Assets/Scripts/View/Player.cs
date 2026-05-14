using Mics;
using UnityEngine;

namespace Player
{
    public class Player : View
    {
        private CharacterController _characterController;
        private float _runSpeed = 10;

        private void Awake()
        {
            _characterController = GetComponent<CharacterController>();
        }

        public void FixedUpdate()
        {
            _characterController.Move(_runSpeed * Time.deltaTime * transform.forward);
        }

        public override string Name => Consts.V_Player;

        public override void HandleEvent(object data = null)
        {
            throw new System.NotImplementedException();
        }
    }
}