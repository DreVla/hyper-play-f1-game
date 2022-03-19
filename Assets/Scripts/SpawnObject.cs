using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObject : MonoBehaviour
{
    public GameObject[] objects;

    void Start()
    {
        int rand = Random.Range(0, objects.Length);
        var newObject = Instantiate(objects[rand], transform.position, Quaternion.identity);
        newObject.transform.parent = gameObject.transform;
    }
}
