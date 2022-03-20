using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingHotdog : MonoBehaviour
{
    [SerializeField, Tooltip("Flying speed")]
    private float speed = 0.1f;
    private int direction;

    // Setting up the monster
    public void SetUp(Vector3 _spawnPosition, int _direction)
    {
        direction = _direction;
        if (direction == -1)
        {
            gameObject.GetComponent<SpriteRenderer>().flipX = true;
        }

        gameObject.transform.position = _spawnPosition;
    }

    private void FixedUpdate()
    {
        transform.position += new Vector3(speed * direction, -Time.fixedDeltaTime, 0);
        

        // Checking the direction to determine which side of the screen it needs to reach
        if (direction == 1)
        {
            transform.Rotate(Vector3.forward * -Time.fixedDeltaTime * 60);
            if (transform.position.x > Camera.main.transform.position.x + (Camera.main.aspect * Camera.main.orthographicSize) + transform.localScale.x)
            {
                Destroy(gameObject);
            }
        }
        else
        {
            transform.Rotate(Vector3.forward * Time.fixedDeltaTime * 60);
            if (transform.position.x < Camera.main.transform.position.x - (Camera.main.aspect * Camera.main.orthographicSize) - transform.localScale.x)
            {
                Destroy(gameObject);
            }
        }
    }
}
