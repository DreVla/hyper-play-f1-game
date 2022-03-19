using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthController : MonoBehaviour
{
    public int health = 3;
    public GameOver gameOver;
    public Image healthBar;
    public Sprite health0, health1, health2, health3;
    public ParticleSystem explosionParticle;

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
            explosionParticle.Play();
            health -= 1;
        }
        else if(collision.collider.tag == "Bonus")
        {
            if (health < 4)
            {
                health += 1;
            }           
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Wall")
        {
            health -= 1;
            SwitchSPrite(health);
            Destroy(collision.gameObject);
            explosionParticle.Play();
        }
        else if (collision.tag == "Bonus")
        {
            if (health < 4)
            {
                health += 1;
                SwitchSPrite(health);
            }

            Destroy(collision.gameObject);
        }
    }

    public void SwitchSPrite(int healthLeft)
    {
        switch(healthLeft)
        {
            case int healthLevel when healthLevel == 0:
                healthBar.sprite = health0;
                break;
            case int healthLevel when healthLevel == 1:
                healthBar.sprite = health1;
                break;
            case int healthLevel when healthLevel == 2:
                healthBar.sprite = health2;
                break;
            case int healthLevel when healthLevel == 3:
                healthBar.sprite = health3;
                break;
        }
    }
}
