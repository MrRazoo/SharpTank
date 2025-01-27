using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject PausePanel;
    public static bool isGamePause = false;
    public void LoadNextLevel()
    {
        int currentIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadSceneAsync(currentIndex+1);
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(!isGamePause)
            {
                Pause();

            }else
            {
                Resume();
            }
        }

    }

    public void Quit()
    {
        Application.Quit();
        Debug.Log("Application Closed");
    }

    public void Resume()
    {
        PausePanel.SetActive(false);
        Time.timeScale = 1f;
        isGamePause = false;
    }

    public void Pause()
    {
        PausePanel.SetActive(true);
        Time.timeScale = 0f;
        isGamePause = true;
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadSceneAsync("Menu");
        Time.timeScale = 1f;
    }
}
