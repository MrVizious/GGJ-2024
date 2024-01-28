using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamButtonsController : MonoBehaviour
{
    public List<CamButton> camButtons;

    private void Start()
    {
        if (camButtons == null || camButtons.Count <= 0)
        {
            camButtons = new List<CamButton>();
            camButtons.AddRange(GetComponentsInChildren<CamButton>());
        }

        for (int i = 0; i < camButtons.Count; i++)
        {
            CamButton currentButton = camButtons[i];
            currentButton.onClick.AddListener(() => DeselectAllButtonsExceptFor(currentButton));
        }
    }

    private void DeselectAllButtonsExceptFor(CamButton camButton)
    {
        camButton.onClick.RemoveListener(() => DeselectAllButtonsExceptFor(camButton));
        for (int i = 0; i < camButtons.Count; i++)
        {
            if (camButtons[i] != camButton) camButtons[i].currentState = CamButton.ButtonState.off;
        }
    }

}
