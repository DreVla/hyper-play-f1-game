using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PitStoppers : MonoBehaviour
{
    private Transform target;
    public Rigidbody2D rb;
    public GameObject blood;
    public GameObject spawnPoint;

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

    void OnTriggerEnter2D (Collider2D other) {
        if (other.gameObject.tag == "Car") {
            Instantiate(blood, transform.position, Quaternion.identity);
            Destroy(gameObject);
            blood.transform.Translate(0, -5 * Time.deltaTime, 0);
            //spawnPoint.transform.parent = gameObject.transform;
            //health -= 1;
        }
    }
}
