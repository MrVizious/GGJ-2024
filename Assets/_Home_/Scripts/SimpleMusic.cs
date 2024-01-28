using System.Collections;
using System.Collections.Generic;
using DesignPatterns;
using ExtensionMethods;
using UnityEngine;
using UtilityMethods;

public class SimpleMusic : Singleton<SimpleMusic>
{
    public AudioClip musicClip;
    private AudioSource _audioSource;
    private AudioSource audioSource
    {
        get
        {
            if (_audioSource == null) _audioSource = this.GetOrAddComponent<AudioSource>();
            return _audioSource;
        }
    }
    void Start()
    {
        audioSource.clip = musicClip;
        audioSource.loop = true;
        audioSource.volume = 0.02f;
        audioSource.Play();
    }
}
