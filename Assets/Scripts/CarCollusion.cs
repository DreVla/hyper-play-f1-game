using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarCollusion : MonoBehaviour
{
    public GameOver gameOver;
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Competitor")
        {
            gameOver.GameIsOver();
        }
    }
}
