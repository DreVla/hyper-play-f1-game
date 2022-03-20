using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PitStoppers : MonoBehaviour
{
    private Transform target;
    public Rigidbody2D rb;

    void Start()
    {
        target = GameObject.FindWithTag("Car").transform;
        rb = this.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Vector3 direction = target.position - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg + 90;
        rb.rotation = angle;
    }
}
