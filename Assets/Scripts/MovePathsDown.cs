using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePathsDown : MonoBehaviour
{
    void Update() {
        transform.Translate(0, -1 * Time.deltaTime, 0);
        if (gameObject.transform.position.y < -12) {
            Destroy(gameObject);
        }
    }
}
