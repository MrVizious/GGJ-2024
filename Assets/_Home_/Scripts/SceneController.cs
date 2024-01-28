using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DesignPatterns;
using UnityEngine.SceneManagement;

public class SceneController : Singleton<SceneController>
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ChangeGameScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    public void GoToMainMenu()
    {
        ChangeGameScene("MainMenu");
    }

    public void GoToShowScene()
    {
        Debug.Log("ShowScene");
        ChangeGameScene("ShowScene");
    }

    public void GoToLoseScene()
    {
        ChangeGameScene("LoseScene");
    }
    public void GoToWinScene()
    {
        ChangeGameScene("WinScene");
    }
    public void GoToCredits()
    {
        ChangeGameScene("CreditScene");
    }
}
