using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using Audio;
using ExtensionMethods;
using Sirenix.OdinInspector;

[RequireComponent(typeof(ShowManager))]
public class SoundManager : MonoBehaviour
{
    private HashSet<AudioClip> playingSounds = new HashSet<AudioClip>();

    private ShowManager _showManager;
    private ShowManager showManager
    {
        get
        {
            if (_showManager == null) _showManager = GetComponent<ShowManager>();
            return _showManager;
        }
    }

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
