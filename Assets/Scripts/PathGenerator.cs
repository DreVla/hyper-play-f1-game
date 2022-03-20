using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathGenerator : MonoBehaviour
{
    public GameObject[] pathTemplates;
    public GameObject pitStop;
    public float timer = 2.0f;
    public int pathsInstantiated = 0;

    void Start() {
        int rand = Random.Range(0, pathTemplates.Length);
        Instantiate(pathTemplates[rand], transform.position, Quaternion.identity);
    }

    void Update() {
        timer -= Time.deltaTime;
        
        if(timer <= 0.0f) {
            if(pathsInstantiated % 5 == 0) {
                Instantiate(pitStop);
                timer = 2.0f;
                pathsInstantiated++;
            }
            else {
                int rand = Random.Range(0, pathTemplates.Length);
                Instantiate(pathTemplates[rand], transform.position, Quaternion.identity);
                timer = 2.0f;
                pathsInstantiated++;
            }
        }
    }    


}
