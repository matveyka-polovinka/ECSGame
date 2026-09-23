using Assets.Scripts.InputProcessing;
using Assets.Scripts.InputProcessing.Systems;
using Assets.Scripts.MonoController;
using Assets.Scripts.Movement;
using Scellecs.Morpeh;
using UnityEngine;

namespace Assets.Scripts.Infrastructure
{
    public sealed class GameRunner : MonoBehaviour
    {
        [SerializeField] private Rigidbody _mainHeroRB;
        [SerializeField] private PlayerAnimationController _animController;
        private void Awake()
        {
            World world = World.Default;

            Entity mainHero = world.CreateEntity();

            world.GetStash<MoveSpeed>().Add(mainHero, new MoveSpeed { Value = 10f });
            world.GetStash<Velocity>().Add(mainHero);
            world.GetStash<InputComponent>().Add(mainHero);
            world.GetStash<GravityMarker>().Add(mainHero);

            world.GetStash<AnimationComponent>().Add(mainHero, new AnimationComponent { Value = _animController });
            world.GetStash<RigidbodyComponent>().Add(mainHero, new RigidbodyComponent { Value = _mainHeroRB });

            var group = world.CreateSystemsGroup();

            group.AddSystem(new InputPlayerMove());
            group.AddSystem(new InputPlayerJump());
            group.AddSystem(new PlayerGravity());
            group.AddSystem(new MoveRigidbodySystem());
            group.AddSystem(new AnimationControlSystem());

            world.AddSystemsGroup(0, group);

            world.Commit();
        }
    }
}