using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Sirenix.OdinInspector;

public class Screen : MonoBehaviour
{
    [OnValueChanged("UpdateCameraRenderTexture")]
    private RenderTexture _currentRenderTexture;
    public RenderTexture currentRenderTexture
    {
        get
        {
            if (_currentRenderTexture == null) _currentRenderTexture = (RenderTexture)image.texture;
            return _currentRenderTexture;
        }
        private set
        {
            _currentRenderTexture = value;
            UpdateCameraRenderTexture();
        }
    }


    private RawImage _image;
    private RawImage image
    {
        get
        {
            if (_image == null) _image = GetComponent<RawImage>();
            return _image;
        }
    }

    public void UpdateCameraRenderTexture()
    {
        image.texture = currentRenderTexture;
    }

    public void SetCurrentTextureToScreen(Screen screenToSet)
    {
        screenToSet.currentRenderTexture = currentRenderTexture;
    }
}