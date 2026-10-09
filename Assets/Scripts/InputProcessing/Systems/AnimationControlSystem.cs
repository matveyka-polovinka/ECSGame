using Assets.Scripts.Movement;
using Scellecs.Morpeh;
using UnityEngine;

namespace Assets.Scripts.InputProcessing.Systems
{
    public sealed class AnimationControlSystem : ISystem
    {
        public World World { get; set; }
        private Filter _controllEntities;
        private Stash<AnimationComponent> _anim;
        private Stash<RigidbodyComponent> _rb;
        public void Dispose() { }
        public void OnAwake()
        {
            _controllEntities = World.Filter
                .With<AnimationComponent>()
                .With<RigidbodyComponent>()
                .With<InputComponent>()
                .Build();

            _anim = World.GetStash<AnimationComponent>();
            _rb = World.GetStash<RigidbodyComponent>();
        }
        public void OnUpdate(float deltaTime)
        {
            foreach (Entity entity in _controllEntities)
            {
                ref AnimationComponent anim = ref _anim.Get(entity);
                ref RigidbodyComponent rb = ref _rb.Get(entity);

                //Debug.Log(rb.Value.velocity);

                if (rb.Value.velocity.x != 0f && rb.Value.velocity.z != 0f) anim.Value.SetRun();
                else anim.Value.SetIdle();

                if (rb.Value.velocity.y > 0f) anim.Value.SetJump();
            }
        }
    }
}