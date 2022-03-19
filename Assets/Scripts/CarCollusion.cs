using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarCollusion : MonoBehaviour
{
    public GameManager gameManager;
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Competitor")
        {
            gameManager.GameEnd();
        }
    }
}
