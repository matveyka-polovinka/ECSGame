using Assets.Scripts.Movement;
using Scellecs.Morpeh;
using UnityEngine;

namespace Assets.Scripts.InputProcessing.Systems
{
    public sealed class InputPlayerJump : ISystem
    {
        public World World { get; set; }
        private Filter _controllEntities;
        private Stash<RigidbodyComponent> _stash;
        public void Dispose() { }
        public void OnAwake()
        {
            _controllEntities = World.Filter.With<InputComponent>().Build();
            _stash = World.GetStash<RigidbodyComponent>();
        }
        public void OnUpdate(float deltaTime)
        {
            Vector3 input = Input.GetKeyDown(KeyCode.Space) ? Vector3.up : Vector3.zero;
            foreach (Entity entity in _controllEntities)
            {
                ref RigidbodyComponent rb = ref _stash.Get(entity);

                if (Physics.Raycast(rb.Value.position, Vector3.down, out hit, 1.1f))
                    rb.Value.AddForce(input * 7, ForceMode.Impulse);
            }
        }
        RaycastHit hit;
    }
}