using Assets.Scripts.MonoController;
using Scellecs.Morpeh;
using UnityEngine;

namespace Assets.Scripts.Movement
{
    public struct MoveSpeed : IComponent
    {
        public float Value;
    }
    public struct Velocity : IComponent
    {
        public Vector3 Value;
    }
    public struct GravityMarker : IComponent { }
    public struct RigidbodyComponent : IComponent
    {
        public Rigidbody Value;
    }
    public struct AnimationComponent : IComponent
    {
        public PlayerAnimationController Value;
    }
}