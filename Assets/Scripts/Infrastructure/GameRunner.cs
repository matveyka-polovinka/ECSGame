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
        [SerializeField] private MainHeroCustomizer _mainHeroCustomizer;
        private void Awake()
        {
            World world = World.Default;

            _mainHeroCustomizer.SetHero(world);

            var group = world.CreateSystemsGroup();

            world.AddSystemsGroup(0, AddSystem.GetSystemGroup(group));

            world.Commit();
        }
    }
}