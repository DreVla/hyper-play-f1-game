using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using System.Collections.Generic;

public class PauseMenu : MonoBehaviour
{
    public static bool gameIsPaused = false;
    public GameObject pauseOverlay;
    public GameManager gameManager;

    void Start()
    {
        gameIsPaused = false;
        Time.timeScale = 1f;
        pauseOverlay.SetActive(false);
    }

    public void PauseGame()
    {
        if (gameManager.gameIsOver == false)
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
        else
        {
            pauseOverlay.SetActive(false);
        }
    }

    void OnApplicationPause()
    {
        if (gameManager.gameIsOver == true)
        {
            pauseOverlay?.SetActive(false);
        }
        else
        {
            gameIsPaused = true;
            Time.timeScale = 0f;
            pauseOverlay.SetActive(true);
        }

    }
}
