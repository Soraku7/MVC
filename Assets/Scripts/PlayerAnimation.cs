using Global;
using Mics;
using UnityEngine;

namespace DefaultNamespace
{
    public class PlayerAnimation : MonoBehaviour
    {
        [SerializeField] private Animation anim;
        private string nowAnimName;
        private Player _player;

        private void Awake()
        {
            anim = GetComponent<Animation>();
            _player = GetComponent<Player>();

            _player.Order += PlayerAnim;

            PlayRun();
        }

        private void Update()
        {
            if (anim[nowAnimName].name != "run")
            {
                if (anim[nowAnimName].normalizedTime >= 0.96f)
                {
                    PlayRun();
                }
            }

            anim.Play(nowAnimName);
        }

        private void PlayRun()
        {
            nowAnimName = "run";
        }

        private void PlayAnimation(string animName)
        {
            nowAnimName = animName;
        }

        public void PlayerAnim(inputDirState inputGesture)
        {
            switch (inputGesture)
            {
                case inputDirState.Up:
                    PlayAnimation("jump");
                    PlaySound("Se_UI_Jump");
                    break;
                case inputDirState.Down:
                    PlayAnimation("roll");
                    PlaySound("Se_UI_Roll");
                    break;
                case inputDirState.Left:
                    PlayAnimation("left_jump");
                    PlaySound("Se_UI_Speed");
                    break;
                case inputDirState.Right:
                    PlayAnimation("right_jump");
                    PlaySound("Se_UI_Speed");
                    break;
                default:
                    break;
            }
        }

        public void PlaySound(string audioName)
        {
            GameManager.Instance.sound.PlayEffectAudio(audioName);
        }
    }
}