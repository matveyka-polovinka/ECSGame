using Scellecs.Morpeh;
using UnityEngine;

namespace Assets.Scripts.InputProcessing.Systems
{
    public sealed class InputPlayerJump : ISystem
    {
        public World World { get; set; }
        private Filter _controllEntities;
        private Stash<InputComponent> _stash;
        public void Dispose() { }
        public void OnAwake()
        {
            _controllEntities = World.Filter.With<InputComponent>().Build();
            _stash = World.GetStash<InputComponent>();
        }
        public void OnUpdate(float deltaTime)
        {
            Vector3 input = Input.GetKeyDown(KeyCode.Space) ? Vector3.up : Vector3.zero;
            foreach (Entity entity in _controllEntities)
            {
                ref InputComponent inputDirection = ref _stash.Get(entity);

                if (inputDirection.Value.y != 0f) return;

                inputDirection.Value += input;
            }
        }
    }
}