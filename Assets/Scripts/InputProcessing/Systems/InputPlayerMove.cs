using Assets.Scripts.Movement;
using Scellecs.Morpeh;
using UnityEngine;

namespace Assets.Scripts.InputProcessing.Systems
{
    public sealed class InputPlayerMove : ISystem
    {
        public World World { get; set; }
        private Filter _controllEntities;
        private Stash<InputComponent> _stash;
        private Stash<MoveSpeed> _velstash;
        public void Dispose() { }
        public void OnAwake()
        {
            _controllEntities = World.Filter.With<InputComponent>().Build();

            _stash = World.GetStash<InputComponent>();
            _velstash = World.GetStash<MoveSpeed>();
        }
        public void OnUpdate(float deltaTime)
        {
            Vector3 input = new Vector3(-Input.GetAxisRaw("Horizontal"),0,Input.GetAxisRaw("Vertical")).normalized;
            foreach(Entity entity  in _controllEntities)
            {
                ref InputComponent inputDirection = ref _stash.Get(entity);

                ref MoveSpeed speed = ref _velstash.Get(entity);

                inputDirection.Value = Vector3.up * inputDirection.Value.y;
                inputDirection.Value += input * speed.Value;
            }
        }
    }
}