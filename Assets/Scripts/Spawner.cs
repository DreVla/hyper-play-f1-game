using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [SerializeField, Tooltip("Min time until next spawn")]
    public float minSpawnTime;
    [SerializeField, Tooltip("Max time until next spawn")]
    public float maxSpawnTime;

    [SerializeField, Tooltip("Max range above the player a monster can spawn")]
    public float spawnRangeAbove;
    [SerializeField, Tooltip("Max range below the player a monster can spawn")]
    public float spawnRangeBelow;

    [SerializeField, Tooltip("Prefab for flying monsters")]
    public GameObject HotdogPrefab;

    public GameObject playerCar;
    private List<GameObject> flyingHotDog = new List<GameObject>();
    private float randomTimer;

    void Start()
    {
        randomTimer = Random.Range(minSpawnTime, maxSpawnTime);
    }

    private void FixedUpdate()
    {
        if (randomTimer > 0)
        {
            randomTimer -= Time.deltaTime;
        }
        else
        {
            GameObject newHotdog = Instantiate(HotdogPrefab);
            int direction;
            float spawnX;

            if (Random.Range(0, 2) == 0)
            {
                direction = 1;
                spawnX = Camera.main.transform.position.x - (Camera.main.aspect * Camera.main.orthographicSize) - newHotdog.transform.localScale.x;
            }
            else
            {
                direction = -1;
                spawnX = Camera.main.transform.position.x + (Camera.main.aspect * Camera.main.orthographicSize) + newHotdog.transform.localScale.x;
            }
            newHotdog.GetComponent<FlyingHotdog>().SetUp(new Vector3(spawnX, Random.Range(playerCar.transform.position.y - spawnRangeBelow, playerCar.transform.position.y + spawnRangeAbove), 0), direction);
            flyingHotDog.Add(newHotdog);
            randomTimer = Random.Range(minSpawnTime, maxSpawnTime);
        }
    }

    // Kills all the flying monsters
    public void KillAll()
    {
        while (flyingHotDog.Count != 0)
        {
            Destroy(flyingHotDog[0].gameObject);
            flyingHotDog.RemoveAt(0);
        }
    }
}
