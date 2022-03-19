using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class PauseMenu : MonoBehaviour
{
    public static bool gameIsPaused = false;
    public GameObject pauseOverlay;

    void Start()
    {
        gameIsPaused = false;
        Time.timeScale = 1f;
        pauseOverlay.SetActive(false);
    }

    public void PauseGame()
    {
        if (gameIsPaused)
        {
            Time.timeScale = 1f;
            pauseOverlay.SetActive(false);
            gameIsPaused = false;
        }
        else
        {
            Time.timeScale = 0f;
            pauseOverlay.SetActive(true);
            gameIsPaused = true;
        }
    }

    void OnApplicationPause()
    {
        gameIsPaused = true;
        Time.timeScale = 0f;
        pauseOverlay.SetActive(true);
    }
}
