using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SettingsScript : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene("MainStage1");
    }

    public void BindingsButton()
    {
        SceneManager.LoadScene("BindingsScene");
    }

    public void OptionsButton()
    {
        SceneManager.LoadScene("SettingsScene");
    }

    public void QuitGame()
    {
        Debug.Log("Quit the game!");
        Application.Quit();
    }

    public void ReturnMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
