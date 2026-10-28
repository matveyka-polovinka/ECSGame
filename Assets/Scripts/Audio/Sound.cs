using System;
using UnityEngine;

namespace Assets.Scripts.Audio
{
    public class Sound : MonoBehaviour
    {
        public static Action<SoundInstruction> Play;
    }

    public class SoundInstruction
    {
        public SoundInstruction(string clipName)
        {
            ClipName = clipName;
        }
        public SoundInstruction(string clipName, float volume)
        {
            ClipName = clipName;
            Volume = volume;
        }
        public SoundInstruction(string clipName, float volume, float pitch)
        {
            ClipName = clipName;
            Volume = volume;
            Pitch = pitch;
        }
        public SoundInstruction(string clipName, float volume, float pitch, float delay)
        {
            ClipName = clipName;
            Volume = volume;
            Pitch = pitch;
            Delay = delay;
        }

        public string ClipName = "";

        public float Volume = 1.0f;
        public float Pitch = 1.0f;
        public float Delay = 0.0f;

        public bool IsMain = false;
        public bool IsSlow = false;
    }
}