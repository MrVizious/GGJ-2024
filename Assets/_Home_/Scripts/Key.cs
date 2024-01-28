using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Key : StateButton
{
    public BazingaButton bazingaButton;

    protected override void OnClick()
    {
        if (currentState == ButtonState.on) return;
        bazingaButton.keysTurned++;
        currentState = ButtonState.on;
    }

}
