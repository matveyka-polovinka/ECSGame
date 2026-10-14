using Assets.Scripts.InputProcessing;
using Assets.Scripts.MonoController;
using Assets.Scripts.Movement;
using Scellecs.Morpeh;
using UnityEngine;

[System.Serializable]
public class MainHeroCustomizer
{
    [SerializeField] private Rigidbody _rb;
    [SerializeField] private PlayerAnimationController _anim;
    public Entity SetHero(World world)
    {
        Entity mainHero = world.CreateEntity();

        world.GetStash<MoveSpeed>().Add(mainHero, new MoveSpeed { Value = 10f });
        world.GetStash<Velocity>().Add(mainHero);
        world.GetStash<InputComponent>().Add(mainHero);
        world.GetStash<GravityMarker>().Add(mainHero);

        world.GetStash<AnimationComponent>().Add(mainHero, new AnimationComponent { Value = _anim });
        world.GetStash<RigidbodyComponent>().Add(mainHero, new RigidbodyComponent { Value = _rb });

        return mainHero;
    }
}