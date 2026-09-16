using Assets.Scripts.Movement;
using Scellecs.Morpeh;
using UnityEngine;

namespace Assets.Scripts.InputProcessing.Systems
{
    public sealed class PlayerGravity : ISystem
    {
        public World World { get; set; }

        private Filter _filter;
        private Stash<InputComponent> _stash;

        public void Dispose() { }
        public void OnAwake()
        {
            _filter = World.Filter
                .With<InputComponent>()
                .With<GravityMarker>()
                .Build();
            _stash = World.GetStash<InputComponent>();
        }

        public void OnUpdate(float deltaTime)
        {
            foreach(Entity ntt in _filter)
            {
                ref var vel = ref _stash.Get(ntt);

                float vely = vel.Value.y;
                vely = vely > 0f ? vely - Time.deltaTime : 0f;

                vel.Value =
                    Vector3.right * vel.Value.z +
                    Vector3.forward * vel.Value.x +
                    Vector3.up * vely;
            }
        }
    }
}