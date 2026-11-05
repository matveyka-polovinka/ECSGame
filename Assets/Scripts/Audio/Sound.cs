using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

namespace Assets.Scripts.Audio
{
    public class Sound : MonoBehaviour
    {
        [SerializeField] private List<string> AudioNames;
        [SerializeField] private WebGLAudioLoader _loader;
        [SerializeField] private AudioSource _main, _effect;
        [SerializeField] private AudioMixer _mixer;

        private bool _isSoundsLoad = false;

        public static Action<SoundInstruction> Play, PlayMain;
        public static Action StopPlayMain;

        private void Start()
        {
            Play += PlaySound;
            PlayMain += PlaySound;
            StopPlayMain += StopSoundMain;

            StartCoroutine(LoadAudioList());
        }
        private void PlaySound(SoundInstruction instruction)
        {
            if (_isSoundsLoad) StartCoroutine(PlaySoundCoroutine(instruction));
        }
        private void StopSoundMain() => _main.Stop();
        private IEnumerator PlaySoundCoroutine(SoundInstruction instruction)
        {
            if (!_loader.IsProcessLoad()) yield return null;

            _loader.LoadAudio(instruction.ClipName);
            if (!_loader.IsProcessLoad()) yield return null;

            AudioClip clip = _loader.GetAudioClip();

            if(instruction.Delay > 0f) yield return new WaitForSeconds(instruction.Delay);

            if (instruction.IsMain)
            {
                _main.clip = clip;
                _main.pitch = instruction.Pitch;
                _main.volume = instruction.Volume;

                if (instruction.IsSlow) StartCoroutine(PlaySlowed());
                else _main.Play();
            }
            else
            {
                _effect.pitch = instruction.Pitch;
                _effect.PlayOneShot(clip, instruction.Volume);
            }
        }
        private IEnumerator PlaySlowed()
        {
            _mixer.SetFloat("Main", -80f);
            _main.Play();

            float vol = -80f;

            while(vol < -1f)
            {
                _mixer.SetFloat("Main", vol);
                yield return new WaitForSeconds(0.2f);
                vol += 10f;
            }
        }
        private IEnumerator LoadAudioList()
        {
            foreach (string clipName in AudioNames)
            {
                _loader.LoadAudio(clipName);
                if (!_loader.IsProcessLoad()) yield return null;
            }
            _isSoundsLoad = true;
        }
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