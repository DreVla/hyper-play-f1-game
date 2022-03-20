using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePathsDown : MonoBehaviour
{
    //int speed = -1;

    void Update() {
        transform.Translate(0, -5 * Time.deltaTime, 0);
        if (gameObject.transform.position.y < -12) {
            Destroy(gameObject);
            //speed =- 1;
        }
    }
}
