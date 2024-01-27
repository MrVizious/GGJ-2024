using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class ShowManager : MonoBehaviour
{
    public float rating = 100f;

    public Screen mainScreen;

    public HashSet<AudioClip> acceptedSounds = new HashSet<AudioClip>();
    public HashSet<AudioClip> requiredSounds = new HashSet<AudioClip>();
    public HashSet<RenderTexture> acceptedRenderTextures = new HashSet<RenderTexture>();
    [SerializeField]
    [OnValueChanged("UpdateCurrentRenderTexture")]
    private RenderTexture _currentRenderTexture;
    private RenderTexture currentRenderTexture
    {
        get
        {
            if (_currentRenderTexture == null) _currentRenderTexture = mainScreen?.currentRenderTexture;
            return _currentRenderTexture;
        }
        set
        {
            _currentRenderTexture = value;
            UpdateCurrentRenderTexture();
        }
    }

    private void UpdateCurrentRenderTexture()
    {
        if (mainScreen == null)
        {
            Debug.LogError("There is no Main Screen referenced", this);
            return;
        }
        mainScreen.currentRenderTexture = currentRenderTexture;
    }

    public void AddAcceptedSound(AudioClip newAudioClip)
    {
        if (!acceptedSounds.Add(newAudioClip))
        {
            Debug.LogError("The sound was already added to accepted sounds. Please, check this", this);
        }
    }
    public void AddRequiredSound(AudioClip newAudioClip)
    {
        if (!acceptedSounds.Remove(newAudioClip))
        {
            Debug.LogError("The sound wasn't in accepted sounds before being added. Please, check this", this);
        }
        requiredSounds.Add(newAudioClip);
    }

    public void RemoveRequiredSound(AudioClip oldAudioClip)
    {
        if (!requiredSounds.Remove(oldAudioClip))
        {
            Debug.LogError("The sound wasn't in required sounds! Check why you are removing it", this);
        }
        acceptedSounds.Add(oldAudioClip);
    }

    public void RemoveAcceptedSound(AudioClip oldAudioClip)
    {
        if (!acceptedSounds.Remove(oldAudioClip))
        {
            Debug.LogError("The sound wasn't in accepted sounds before being deleted. Please, check this", this);
        }
    }



}
