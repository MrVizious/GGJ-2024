using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;

public class PageController : MonoBehaviour
{
    public List<Sprite> sprites = new List<Sprite>();
    public Page previousPage, currentPage, nextPage;
    [SerializeField]
    private int _currentPageIndex = 0;
    public int currentPageIndex
    {
        get => _currentPageIndex;
        set
        {
            value = Mathf.Clamp(value, 0, sprites.Count - 1);
            _currentPageIndex = value;
        }
    }

    public void SetPageIndex(int newIndex)
    {
        Debug.Log("New Index: " + newIndex + ", Sprites count: " + sprites.Count);
        if (newIndex < 0 || newIndex >= sprites.Count)
        {
            return;
        }
        currentPageIndex = newIndex;

        if (currentPageIndex <= 0) previousPage.sprite = null;
        else previousPage.sprite = sprites[currentPageIndex - 1];

        currentPage.sprite = sprites[currentPageIndex];

        if (currentPageIndex >= sprites.Count - 1) nextPage.sprite = null;
        else nextPage.sprite = sprites[currentPageIndex + 1];
    }

    [Button]
    public void NextPage()
    {
        SetPageIndex(currentPageIndex + 1);
    }
    [Button]
    public void PreviousPage()
    {
        SetPageIndex(currentPageIndex - 1);
    }
}
