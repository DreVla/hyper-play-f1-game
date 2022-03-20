using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarCollusion : MonoBehaviour
{
    public GameOver gameOver;
    public JoystickPlayerExample playerController;
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Competitor")
        {
            gameOver.GameIsOver();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Competitor")
        {
            gameOver.GameIsOver();
        }
        if (collision.tag == "Drunk")
        {
            playerController.ReverseControls();
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Grass" && collision.tag != "Asphalt")
        {
            playerController.increaseDragOnGrass();
            Debug.Log("On grass");
        } 
        if(collision.tag == "Asphalt")
        {
            playerController.dragOnAsphalt();
            Debug.Log("On asphalt");
        }
    }
}
