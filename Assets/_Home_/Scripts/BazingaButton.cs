using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BazingaButton : StateButton
{
    public Sprite openSprite;
    public int keysTurned = 0;
    private bool open = false;
    private Sprite closeSprite;

    protected override void Start()
    {
        base.Start();
        closeSprite = offSprite;
    }
    protected override void OnClick()
    {
        if (open == false)
        {
            open = true;
            image.sprite = openSprite;
            offSprite = openSprite;
            image.color = Color.white;
            return;
        }
        else if (keysTurned == 2)
        {
            currentState = ButtonState.on;
            return;
        }
        else
        {
            open = false;
            image.sprite = closeSprite;
            image.color = Color.white;
            return;
        }
    }

    protected override void OnPointerEnter()
    {
        if (open == false)
        {
            image.color = Color.cyan;
            return;
        }
        if (currentState == ButtonState.off) currentState = ButtonState.hover;
    }

    protected override void OnPointerExit()
    {
        if (open == false)
        {
            image.color = Color.white;
            return;
        }
        if (currentState == ButtonState.hover) currentState = ButtonState.off;
    }

}
