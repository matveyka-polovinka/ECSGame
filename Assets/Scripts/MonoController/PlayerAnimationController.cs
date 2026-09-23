using UnityEngine;

namespace Assets.Scripts.MonoController
{
    public class PlayerAnimationController : MonoBehaviour
    {
        public void SetIdle()
        {
            Debug.Log("<color=green> Стоит, ковыряет в носу");
        }
        public void SetRun()
        {
            Debug.Log("<color=red> Бежит");
        }
        public void SetJump()
        {
            Debug.Log("<color=yellow> Прыгает");
        }
    }
}