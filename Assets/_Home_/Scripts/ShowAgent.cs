using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

[RequireComponent(typeof(Animator))]
public class ShowAgent : MonoBehaviour
{
    private Animator _animator;
    protected Animator animator
    {
        get
        {
            if (_animator == null) _animator = GetComponent<Animator>();
            return _animator;
        }
    }

    private ShowManager _showManager;
    private ShowManager showManager
    {
        get
        {
            if (_showManager == null) _showManager = FindObjectOfType<ShowManager>();
            return _showManager;
        }
    }

    [Button]
    public void StartShow()
    {
        animator.Play("StartShow");
    }

    public void AddAcceptedSound(AudioClip newAudioClip)
    {
        showManager.AddAcceptedSound(newAudioClip);
    }
    public void AddRequiredSound(AudioClip newAudioClip)
    {
        showManager.AddRequiredSound(newAudioClip);
    }

    public void RemoveRequiredSound(AudioClip oldAudioClip)
    {
        showManager.RemoveRequiredSound(oldAudioClip);
    }

    public void RemoveAcceptedSound(AudioClip oldAudioClip)
    {
        showManager.RemoveAcceptedSound(oldAudioClip);
    }

    public void AddAcceptedRenderTexture(RenderTexture renderTexture)
    {
        showManager.AddAcceptedRenderTexture(renderTexture);
    }
    public void RemoveAcceptedRenderTexture(RenderTexture renderTexture)
    {
        showManager.RemoveAcceptedRenderTexture(renderTexture);
    }

}
