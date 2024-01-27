using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class audienceRatingController : MonoBehaviour
{
    public ShowManager showManager;
    public Image audienceMeter;
    // Update is called once per frame
    void Update()
    {
        audienceMeter.fillAmount = showManager.rating / 100;
    }
}
