using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOver : MonoBehaviour
{
    public GameManager manager;

    public void GameIsOver()
    {
        manager.GameEnd();
    }
}
