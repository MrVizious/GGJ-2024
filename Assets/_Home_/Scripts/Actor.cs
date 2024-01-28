using System.Collections;
using System.Collections.Generic;
using Audio;
using UnityEngine;
using UnityEngine.UIElements;

public class Actor : ShowAgent
{
    private Vector3 lastPosition;
    private AudioSourceExtended voiceSource;
    private void Start()
    {
        lastPosition = transform.position;
    }
    private void Update()
    {
        Vector3 currentPosition = transform.position;
        animator.SetFloat("Speed", (lastPosition - currentPosition).magnitude * 100f);
        lastPosition = currentPosition;
    }

    public void Play(AudioClip audioClip)
    {
        voiceSource = AudioManager.Instance.PlaySound(audioClip);
        voiceSource.onEndedPlaying += () => StopSpeakingAnimation();
        animator.SetBool("Talking", true);
    }

    private void StopSpeakingAnimation()
    {
        //voiceSource.onEndedPlaying -= () => StopSpeakingAnimation();
        animator.SetBool("Talking", false);
    }

    public void SetAnimationBoolTrue(string animationName)
    {
        animator.SetBool(animationName, true);
    }
    public void SetAnimationBoolFalse(string animationName)
    {
        animator.SetBool(animationName, false);
    }
}
