using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimePanelController : MonoBehaviour
{
    int seconds;
    int minutes;
    [SerializeField] float timer;
    TMP_Text timeText;

    // Start is called before the first frame update
    void Start()
    {
       timeText = GetComponent<TMP_Text>(); 
    }

    // Update is called once per frame
    void Update()
    {
        timeUpdate();
    }

    void timeUpdate(){
        timer += Time.deltaTime;
        seconds = Mathf.FloorToInt(timer%60);
        minutes = Mathf.FloorToInt(timer/60);
        timeText.SetText(string.Format("{0:00}:{1:00}",minutes, seconds));
    }
}
