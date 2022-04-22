using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelSelectButton : MonoBehaviour
{
    public void OnButtonPress()
    {
        SceneManager.LoadScene("LevelSelect");
    }

    public void OnButtonPressOp()
    {
        SceneManager.LoadScene("OptionsMenu");
    }

    public void OnButtonPressBack()
    {
        SceneManager.LoadScene("StartScreen");
    }

    public void OnLevelButtonPress(string lvl)
    {
        VarHolder.crossInformation = lvl;
        SceneManager.LoadScene("Level");
    }

    public void doExitGame()
    {
        Application.Quit();
        Debug.Log("Game is exiting");
    }


}
