using UnityEngine;

namespace Assets.Scripts.MonoController
{
    public class PlayerAnimationController : MonoBehaviour
    {
        [SerializeField] private Animator _animator;
        public void SetIdle()
        {
            Debug.Log(DEBUG_IDLE);

            _animator.SetBool(IS_RUN, false);
        }
        public void SetRun()
        {
            Debug.Log(DEBUG_RUN);

            _animator.SetBool(IS_RUN, true);
        }
        public void SetJump()
        {
            Debug.Log(DEBUG_JUMP);

            _animator.SetTrigger(JUMP);
        }

        private const string
            // -----   ANIMATOR VARIABLES   ----------------------------------
            IS_RUN = "IsRun",
            JUMP = "Jump",

            // -----   DEBUG TEXTS   ---------------------------------------------
            DEBUG_IDLE = "<color=green> Стоит, размахивает руками",
            DEBUG_RUN = "<color=red> Бежит",
            DEBUG_JUMP = "<color=yellow> Прыгает";
    }
}