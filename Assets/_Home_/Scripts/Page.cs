using System.Collections;
using System.Collections.Generic;
using ExtensionMethods;
using UnityEngine;
using UnityEngine.UI;

public class Page : MonoBehaviour
{

    private Image _image;
    private Image image
    {
        get
        {
            if (_image == null) _image = GetComponent<Image>();
            return _image;
        }
    }

    private Sprite _sprite;
    public Sprite sprite
    {
        get
        {
            return image.sprite;
        }
        set
        {
            if (value == null) image.color = Color.white.WithAlpha(0f);
            else
            {
                image.color = Color.white;
                image.sprite = value;
            }
        }
    }


}
