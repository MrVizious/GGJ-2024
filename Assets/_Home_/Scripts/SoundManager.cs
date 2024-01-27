using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Audio;
using ExtensionMethods;
using Sirenix.OdinInspector;

public class SoundManager : MonoBehaviour
{
    public UnityEvent<AudioClip> onSoundPlay = new UnityEvent<AudioClip>();
    private HashSet<AudioClip> playingSounds = new HashSet<AudioClip>();
    [Button]
    public void PlaySound(AudioClip audioClip)
    {
        if (playingSounds.Contains(audioClip))
        {
            Debug.Log("Audio is already playing");
            return;
        }
        playingSounds.Add(audioClip);
        AudioSourceExtended source = AudioManager.Instance.PlaySound(audioClip);
        source.onRelease += () => OnSoundStop(audioClip);
    }

    private void OnSoundStop(AudioClip audioClip)
    {
        Debug.Log("Sound " + audioClip + " ended!");
        playingSounds.Remove(audioClip);
    }
}
