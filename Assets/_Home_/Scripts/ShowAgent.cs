using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using Cysharp.Threading.Tasks;

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

    public async void AddSound(AudioClip newAudioClip)
    {
        showManager.AddAcceptedSound(newAudioClip);
        await UniTask.WaitForSeconds(2f);
        showManager.AddRequiredSound(newAudioClip);
        await UniTask.WaitForSeconds(newAudioClip.length / 2f);
        showManager.RemoveRequiredSound(newAudioClip);
        await UniTask.WaitForSeconds(2f);
        showManager.RemoveAcceptedSound(newAudioClip);
    }

    public async void AddRenderTexture(RenderTexture newRenderTexture)
    {
        showManager.acceptedRenderTextures.Add(newRenderTexture);

        await UniTask.WaitForSeconds(2f);

        showManager.acceptedRenderTextures = new HashSet<RenderTexture>();
        showManager.acceptedRenderTextures.Add(newRenderTexture);

    }

    public void AddRequiredSound(AudioClip newAudioClip)
    {
        showManager.AddRequiredSound(newAudioClip);
    }
    public void RemoveRequiredSound(AudioClip newAudioClip)
    {
        showManager.RemoveRequiredSound(newAudioClip);
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
