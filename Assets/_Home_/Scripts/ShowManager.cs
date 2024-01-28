using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using System.Linq;
using Cysharp.Threading.Tasks;

[RequireComponent(typeof(SoundManager))]
public class ShowManager : MonoBehaviour
{
    public bool SHOWPLAYING = false;

    [SerializeField]
    [Range(0f, 100f)]
    private float _rating = 100f;
    public float rating
    {
        get => _rating;
        set
        {
            value = Mathf.Clamp(value, 0f, 100f);
            _rating = value;
            if (_rating <= 0f) SceneController.Instance.GoToLoseScene();
        }
    }
    [Header("Penalties and rewards")]
    public float rewardPerSecondCamera = 1f;
    public float penaltyPerSecondCamera = 5f;
    public float rewardPerSecondSound = 2f;
    public float penaltyPerSecondSound = 10f;

    [Header("References")]
    public Screen mainScreen;
    public AudioClip bazingaSound;

    public HashSet<AudioClip> acceptedSounds = new HashSet<AudioClip>();
    public HashSet<AudioClip> requiredSounds = new HashSet<AudioClip>();
    public HashSet<RenderTexture> acceptedRenderTextures = new HashSet<RenderTexture>();


    [SerializeField]
    private List<ShowAgent> showAgents = new List<ShowAgent>();

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

    private SoundManager _soundManager;
    private SoundManager soundManager
    {
        get
        {
            if (_soundManager == null) _soundManager = GetComponent<SoundManager>();
            return _soundManager;
        }
    }


    private async void Start()
    {
        showAgents = new List<ShowAgent>(FindObjectsOfType<ShowAgent>());
        await UniTask.WaitForSeconds(30f);
        StartShow();
    }
    private void Update()
    {
        if (!SHOWPLAYING) return;

        CalculateSoundsScore();

        CalculateCameraScore();

    }

    [Button]
    public void StartShow()
    {
        for (int i = 0; i < showAgents.Count; i++)
        {
            showAgents[i].StartShow();
        }
        SHOWPLAYING = true;
    }

    private void CalculateSoundsScore()
    {
        foreach (AudioClip audioClip in soundManager.playingSounds)
        {
            if (audioClip == bazingaSound) rating += rewardPerSecondSound * 2 * Time.deltaTime;
            else if (requiredSounds.Contains(audioClip)) rating += rewardPerSecondSound * Time.deltaTime;
            else if (!acceptedSounds.Contains(audioClip)) rating -= penaltyPerSecondSound * Time.deltaTime;
        }

        foreach (AudioClip audioClip in requiredSounds)
        {
            if (!soundManager.playingSounds.Contains(audioClip)) rating -= penaltyPerSecondSound * Time.deltaTime;
        }
    }

    private void CalculateCameraScore()
    {
        if (acceptedRenderTextures == null || acceptedRenderTextures.Count <= 0) return;
        if (acceptedRenderTextures.Contains(mainScreen.currentRenderTexture))
        {
            rating += rewardPerSecondCamera * Time.deltaTime;
        }
        else
        {
            rating -= penaltyPerSecondCamera * Time.deltaTime;
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
        if (requiredSounds.Contains(newAudioClip))
        {
            Debug.LogError("Sound is already in required sounds");
        }
        if (!acceptedSounds.Add(newAudioClip))
        {
            Debug.LogError("The sound was already added to accepted sounds. Please, check this", this);
        }
        Debug.Log("Added accepted sound: " + newAudioClip);
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

    public void AddAcceptedRenderTexture(RenderTexture renderTexture)
    {
        acceptedRenderTextures.Add(renderTexture);
    }
    public void RemoveAcceptedRenderTexture(RenderTexture renderTexture)
    {
        acceptedRenderTextures.Remove(renderTexture);
    }
}
