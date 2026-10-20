using Assets.Scripts.InputProcessing;
using Assets.Scripts.MonoController;
using Assets.Scripts.Movement;
using Assets.Scripts.UI.Joysticks;
using Scellecs.Morpeh;
using UnityEngine;

[System.Serializable]
public class MainHeroControlCustomizer
{
    [SerializeField] private JoystickController _joystick;
    public Entity SetInput(World world)
    {
        Entity input = world.CreateEntity();

        world.GetStash<JoystickComponent>()
            .Add(input, new JoystickComponent { Value = _joystick });

        return input;
    }
}