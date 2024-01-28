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
    public HashSet<AudioClip> playingSounds = new HashSet<AudioClip>();
    public AudioClip beepClip;
    private AudioSourceExtended beepSource;

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
    public AudioSourceExtended PlaySound(AudioClip audioClip)
    {
        if (playingSounds.Contains(audioClip))
        {
            Debug.Log("Audio is already playing");
            return null;
        }
        playingSounds.Add(audioClip);
        AudioSourceExtended source = AudioManager.Instance.PlaySound(audioClip);
        source.onRelease += () => OnSoundStop(audioClip);
        return source;
    }

    public void BeginBeep()
    {
        beepSource = AudioManager.Instance.PlaySound(beepClip);
        beepSource.audioSource.loop = true;
        playingSounds.Add(beepClip);
    }

    public void StopBeep()
    {
        beepSource?.Stop();
        playingSounds.Remove(beepClip);
    }

    private void OnSoundStop(AudioClip audioClip)
    {
        Debug.Log("Sound " + audioClip + " ended!");
        playingSounds.Remove(audioClip);
    }
}
