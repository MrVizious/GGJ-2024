using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public abstract class StateButton : MonoBehaviour
{
    public Sprite offSprite, onSprite, hoverSprite;
    public UnityEvent onClick = new UnityEvent();
    public UnityEvent onPointerEnter = new UnityEvent();
    public UnityEvent onPointerExit = new UnityEvent();
    private Image _image;
    protected Image image
    {
        get
        {
            if (_image == null) _image = GetComponent<Image>();
            return _image;
        }
    }

    [System.Serializable]
    public enum ButtonState
    {
        off,
        on,
        hover
    }

    [SerializeField]
    private ButtonState _currentState = ButtonState.off;
    public ButtonState currentState
    {
        get => _currentState;
        set
        {
            if (value != _currentState)
            {
                _currentState = value;
                switch (currentState)
                {
                    case ButtonState.off:
                        image.sprite = offSprite;
                        break;
                    case ButtonState.on:
                        image.sprite = onSprite;
                        break;
                    case ButtonState.hover:
                        image.sprite = hoverSprite;
                        break;
                }
            }
        }
    }

    private ExtendedButton _button;
    protected ExtendedButton button
    {
        get
        {
            if (_button == null) _button = GetComponent<ExtendedButton>();
            return _button;
        }
    }

    protected virtual void Start()
    {
        button.onClick.AddListener(() => OnClick());
        button.onPointerEnter.AddListener(() => OnPointerEnter());
        button.onPointerExit.AddListener(() => OnPointerExit());
    }

    protected virtual void OnClick()
    {
        if (currentState == ButtonState.on) return;

        currentState = ButtonState.on;
        onClick.Invoke();
    }

    protected virtual void OnPointerEnter()
    {
        Debug.Log("On Pointer Enter");
        if (currentState == ButtonState.off) currentState = ButtonState.hover;
        onPointerEnter.Invoke();
    }
    protected virtual void OnPointerExit()
    {
        if (currentState == ButtonState.hover) currentState = ButtonState.off;
        onPointerExit.Invoke();
    }
}
