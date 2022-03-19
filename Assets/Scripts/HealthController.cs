using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : MonoBehaviour
{
    public int health;
    public GameOver gameOver;

    void Start()
    {
        health = 100;
    }

    void Update()
    {
       if(health <= 0)
        {
            gameOver.GameIsOver();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.tag == "Wall")
        {
            health -= 10;
            Debug.Log(health.ToString());
        }
        else if(collision.collider.tag == "Bonus")
        {
            if (health < 100)
            {
                health += 10;
                Debug.Log(health.ToString());
            }           
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Wall")
        {
            health -= 10;
            Debug.Log(health.ToString());
            Destroy(collision.gameObject);
        }
        else if (collision.tag == "Bonus")
        {
            if (health < 100)
            {
                health += 10;
                Debug.Log(health.ToString());
            }

            Destroy(collision.gameObject);
        }
    }
}
