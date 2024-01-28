using System.Collections;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

public class TimeScaler : MonoBehaviour
{
    [Range(0f, 5f)]
    [OnValueChanged("UpdateTimeScale")]
    public float timeScale = 1f;

    private void Awake()
    {
        UpdateTimeScale();
    }
    private void UpdateTimeScale()
    {
        Time.timeScale = timeScale;
    }
}
