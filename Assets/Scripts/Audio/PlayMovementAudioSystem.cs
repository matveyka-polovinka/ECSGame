using Assets.Scripts.Infrastructure;
using Assets.Scripts.InputProcessing;
using Assets.Scripts.Movement;
using Scellecs.Morpeh;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Audio
{
    public sealed class PlayMovementAudioSystem : ISystem
    {    
        public World World { get; set; }
        private Filter _filter;
        private Stash<RigidbodyComponent> _rb;
        private Stash<InputComponent> _input;

        private readonly Dictionary<PlayerSoundState, SoundInstruction> SOUNDS = new()
        {
            {PlayerSoundState.Walk, new("Walk") },
            {PlayerSoundState.Jump, new("Jump") },
            {PlayerSoundState.Fall, new("Fall") },
        };
        private PlayerSoundState _last = PlayerSoundState.Idle;
        public PlayerSoundState State
        {
            set
            {
                if (_last == value || value == PlayerSoundState.Idle) return;
                else Sound.Play.Invoke(SOUNDS[value]);
            }
        }

        public void Dispose() { }

        public void OnAwake()
        {
            _filter = World.Filter
                .With<RigidbodyComponent>()
                .With<InputComponent>()
                .Build();

            _rb = World.GetStash<RigidbodyComponent>();
            _input = World.GetStash<InputComponent>();
        }

        public void OnUpdate(float deltaTime)
        {
            foreach(Entity entity in _filter)
            {
                Vector3 velocity = _rb.Get(entity).Value.velocity;
                Vector3 input = _input.Get(entity).Value;

                //if(velocity.y < 0) _player.State = PlayerSoundState.Fall;
                if (false) { }

                else if (velocity.y > 0) State = PlayerSoundState.Jump;
                else if (input != Vector3.zero) State = PlayerSoundState.Walk;
                else State = PlayerSoundState.Idle;
            }
        }

        public enum PlayerSoundState
        {
            Idle, Fall, Jump, Walk,
        }
    }
}