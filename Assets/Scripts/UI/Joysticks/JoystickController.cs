using Scellecs.Morpeh;
using UnityEngine;

namespace Assets.Scripts.UI.Joysticks
{
    public sealed class JoystickController : MonoBehaviour
    {
        [SerializeField] private Joystick _j;
        [field:SerializeField] public Vector3 Input { get; private set; }
        private void Update()
        {
            Input = new Vector3
            (
                Fix(_j.Horizontal),
                0f,
                Fix(_j.Vertical)
            );
        }
        public const float Threshold = 0.3f;
        private float abs;
        private float Fix(float input)
        {
            abs = Mathf.Abs(input);
            if (abs > Threshold) return input / abs;
            else return 0f;
        }
    }
    public struct JoystickComponent : IComponent
    {
        public JoystickController Value;
    }
}