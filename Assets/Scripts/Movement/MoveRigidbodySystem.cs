using Assets.Scripts.InputProcessing;
using Scellecs.Morpeh;
using UnityEngine;

namespace Assets.Scripts.Movement
{
    public sealed class MoveRigidbodySystem : ISystem
    {
        public World World { get; set; }
        private Filter _controllEntities;
        private Stash<InputComponent> _inputStash;
        private Stash<RigidbodyComponent> _rbStash;
        public void Dispose() { }
        public void OnAwake()
        {
            _controllEntities = World.Filter
                .With<InputComponent>()
                .With<RigidbodyComponent>()
                .Build();

            _inputStash = World.GetStash<InputComponent>();
            _rbStash = World.GetStash<RigidbodyComponent>();
        }
        public void OnUpdate(float deltaTime)
        {
            foreach (Entity entity in _controllEntities)
            {
                ref RigidbodyComponent rbComponent = ref _rbStash.Get(entity);
                ref InputComponent inputComponent = ref _inputStash.Get(entity);

                rbComponent.Value.velocity = inputComponent.Value + Vector3.up * rbComponent.Value.velocity.y;
            }
        }
    }
}