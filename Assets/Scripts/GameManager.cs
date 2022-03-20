using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public bool gameIsOver = false;
    public GameObject gameOverOverlay;
    public GameObject score;

    public void GameEnd()
    {
        if(!gameIsOver)
        {
            gameIsOver = true;
            gameOverOverlay.SetActive(true);
            Time.timeScale = 0f;
            score.SetActive(false);
        }
    }

    void newGame()
    {
        SceneManager.LoadScene("Joystick Scene");
    }
}
