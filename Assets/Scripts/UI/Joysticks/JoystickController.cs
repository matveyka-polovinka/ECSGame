using UnityEngine;

namespace Assets.Scripts.UI.Joysticks
{
    public sealed class JoysctickController : MonoBehaviour
    {
        [SerializeField] private Joystick _j;
        public Vector2 Input { get; private set; }
        private void Update()
        {
            Input = new Vector2
            (
                Fix(_j.Vertical),
                Fix(_j.Horizontal)
            );
        }
        private const float Threshold = 0.3f;
        private float abs;
        private float Fix(float input)
        {
            abs = Mathf.Abs(input);
            if (abs > Threshold) return input / abs;
            else return 0;
        }
    }
}