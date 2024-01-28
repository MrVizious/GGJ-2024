using System.Collections;
using System.Collections.Generic;
using Audio;
using UnityEngine;
using UnityEngine.UI;

public class SoundButton : StateButton
{

    public AudioClip audioClip;
    private AudioSourceExtended audioSource;
    private SoundManager _soundManager;
    private SoundManager soundManager
    {
        get
        {
            if (_soundManager == null) _soundManager = FindObjectOfType<SoundManager>();
            return _soundManager;
        }
    }
    protected override void OnClick()
    {
        if (currentState == ButtonState.on) return;
        currentState = ButtonState.on;
        audioSource = soundManager.PlaySound(audioClip);
        audioSource.onEndedPlaying += () => Deselect();
        onClick.Invoke();
    }

    private void Deselect()
    {
        Debug.Log("Turning off");
        audioSource.onEndedPlaying -= () => Deselect();
        currentState = ButtonState.off;
    }
}
