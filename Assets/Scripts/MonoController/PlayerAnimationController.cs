using UnityEngine;

namespace Assets.Scripts.MonoController
{
    public class PlayerAnimationController : MonoBehaviour
    {
        [SerializeField] private Animator _animator;
        public void SetIdle()
        {
            Debug.Log("<color=green> Стоит, размахивает руками");

            _animator.SetBool("IsRun", false);
        }
        public void SetRun()
        {
            Debug.Log("<color=red> Бежит");

            _animator.SetBool("IsRun", true);
        }
        public void SetJump()
        {
            Debug.Log("<color=yellow> Прыгает");
        }
    }
}