using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathGenerator : MonoBehaviour
{
    public GameObject[] pathTemplates;
    public float timer = 10.0f;

    void Start() {
        int rand = Random.Range(0, pathTemplates.Length);
        Instantiate(pathTemplates[rand], transform.position, Quaternion.identity);
    }

    void Update() {
        timer -= Time.deltaTime;
        if(timer <= 0f) {
            int rand = Random.Range(0, pathTemplates.Length);
            Instantiate(pathTemplates[rand], transform.position, Quaternion.identity);
            timer = 10.0f;
        }
    }    


}
