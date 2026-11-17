using Assets.Scripts.Audio;
using UnityEngine;
public class TestScript : MonoBehaviour
{
    private SoundInstruction SI = new("Main");
    public void Play()
    {
        Sound.Play?.Invoke(SI);
    }
}