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
        else if (collision.tag == "Drunk")
        {
            playerController.ReverseControls();
        }
        else if(collision.tag == "Grass")
        {
            playerController.increaseDragOnGrass();
        }
        else if(collision.tag == "Asphalt")
        {
            playerController.dragOnAsphalt();
        }
    }
}
