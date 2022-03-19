using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    bool gameIsOver = false;
    public GameObject gameOverOverlay;
    public void GameEnd()
    {
        if(!gameIsOver)
        {
            gameIsOver = true;
            gameOverOverlay.SetActive(true);
        }
    }

    void newGame()
    {
        SceneManager.LoadScene("Joystick Scene");
    }
}
