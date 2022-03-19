using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathGenerator : MonoBehaviour
{
    public GameObject[] pathTemplates;
    public GameObject pitStop;
    public float timer = 10.0f;
    public int pathsInstantiated = 0;

    void Start() {
        int rand = Random.Range(0, pathTemplates.Length);
        Instantiate(pathTemplates[rand], transform.position, Quaternion.identity);
    }

    void Update() {
        timer -= Time.deltaTime;
        if(timer <= 0f && pathsInstantiated < 3) {
            int rand = Random.Range(0, pathTemplates.Length);
            Instantiate(pathTemplates[rand], transform.position, Quaternion.identity);
            pathsInstantiated++;
            timer = 10.0f;
        }
        else if(timer <= 0f && pathsInstantiated == 1) {
            Instantiate(pitStop);
            timer = 10.0f;
        }
    }    


}
