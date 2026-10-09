using UnityEngine;

namespace Assets.Scripts.MonoController
{
    public class PlayerAnimationController : MonoBehaviour
    {
        [SerializeField] private Animator _animator;
        public void SetIdle()
        {
            _animator.SetBool(IS_RUN, false);
        }
        public void SetRun()
        {
            _animator.SetBool(IS_RUN, true);
        }
        public void SetJump()
        {
            _animator.SetTrigger(JUMP);
        }

        private const string
            // -----   ANIMATOR VARIABLES   ----------------------------------
            IS_RUN = "IsRun",
            JUMP = "Jump";
    }
}