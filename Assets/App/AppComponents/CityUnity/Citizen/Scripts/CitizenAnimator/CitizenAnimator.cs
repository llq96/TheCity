using UnityEngine;
using Zenject;

namespace TheCity.Unity
{
    public class CitizenAnimator
    {
        [Inject] private Animator Animator { get; }

        private static readonly int AnimatorTrigger_Work = Animator.StringToHash("Work");
        private static readonly int AnimatorTrigger_Sleep = Animator.StringToHash("Sleep");
        private static readonly int AnimatorTrigger_Move = Animator.StringToHash("Move");

        private static readonly int AnimatorProperty_Speed = Animator.StringToHash("Speed");

        public void PlayAnimation_Sleep()
        {
            Animator.SetTrigger(AnimatorTrigger_Sleep);
        }

        public void PlayAnimation_Work()
        {
            Animator.SetTrigger(AnimatorTrigger_Work);
        }

        public void PlayAnimation_Move()
        {
            Animator.SetTrigger(AnimatorTrigger_Move);
        }

        public void SetMoveSpeed(float speed)
        {
            Animator.SetFloat(AnimatorProperty_Speed, speed);
        }
    }
}