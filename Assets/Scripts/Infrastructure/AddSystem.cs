using Assets.Scripts.Audio;
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
        new PlayMovementAudioSystem(),
    };
    public static SystemsGroup GetSystemGroup(SystemsGroup group)
    {
        foreach (var system in Systems) group.AddSystem(system);

        return group;
    }
}