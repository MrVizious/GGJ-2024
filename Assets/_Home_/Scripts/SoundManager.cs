using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SoundManager : MonoBehaviour
{
    public UnityEvent<AudioClip> onSoundPlay = new UnityEvent<AudioClip>();
    private HashSet<AudioClip> playingSounds = new HashSet<AudioClip>();
    public void PlaySound(AudioClip audioClip)
    {
        if (playingSounds.Contains(audioClip))
        {
            Debug.Log("Audio is already playing");
        }
        // TODO: Play sound

    }
}
