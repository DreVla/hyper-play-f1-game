using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartScreen : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("Joystick Scene");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
