using Assets.Scripts.UI.Joysticks;
using Scellecs.Morpeh;
using UnityEngine;

namespace Assets.Scripts.InputProcessing.Systems
{
    public sealed class InputPlayerMove : ISystem
    {
        public World World { get; set; }

        private Filter _controllEntities;
        private Stash<InputComponent> _stash;
        private JoystickComponent _joystick;

        public void Dispose() { }
        public void OnAwake()
        {
            _controllEntities = World.Filter.With<InputComponent>().Build();
            _stash = World.GetStash<InputComponent>();

            _joystick =
                World.GetStash<JoystickComponent>()
                .Get(World.Filter.With<JoystickComponent>().Build()
                .GetEntity(0));
        }
        public void OnUpdate(float deltaTime)
        {

            Vector3 input = _joystick.Value.Input;

            foreach(Entity entity  in _controllEntities)
            {
                ref InputComponent inputDirection = ref _stash.Get(entity);
                inputDirection.Value = Vector3.zero;
                inputDirection.Value += input;
            }
        }
    }
}

//Vector3 input = new Vector3
//(
//    Input.GetAxisRaw("Horizontal"),
//    0,
//    Input.GetAxisRaw("Vertical")
//).normalized;