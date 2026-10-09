using Assets.Scripts.InputProcessing.Systems;
using Assets.Scripts.Movement;
using Scellecs.Morpeh;

public static class AddSystem
{
    private static readonly ISystem[] Systems = 
    {
        new InputPlayerMove(),
        new InputPlayerJump(),
        new MoveRigidbodySystem(),
        new AnimationControlSystem(),
    };
    public static SystemsGroup GetSystemGroup(SystemsGroup group)
    {
        foreach (var system in Systems) group.AddSystem(system);

        return group;
    }
}