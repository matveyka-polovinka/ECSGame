using Scellecs.Morpeh;
using UnityEngine;

namespace Assets.Scripts.Infrastructure
{
    public sealed class GameRunner : MonoBehaviour
    {
        [SerializeField] private MainHeroCustomizer _mainHeroCustomizer;
        [SerializeField] private MainHeroControlCustomizer _MHCC;
        private void Awake()
        {
            World world = World.Default;

            _mainHeroCustomizer.SetHero(world);
            _MHCC.SetInput(world);

            var group = world.CreateSystemsGroup();

            world.AddSystemsGroup(0, AddSystem.GetSystemGroup(group));

            world.Commit();
        }
    }
}