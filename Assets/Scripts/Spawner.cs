using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float delayAndSpawnRate = 2;
    public float timeUntilSpawnRateIncrease = 30;

    [SerializeField, Tooltip("Max range above the player a monster can spawn")]
    public float spawnRangeAbove;
    [SerializeField, Tooltip("Max range below the player a monster can spawn")]
    public float spawnRangeBelow;

    [SerializeField, Tooltip("Prefab for flying monsters")]
    public GameObject HotdogPrefab;

    public GameObject playerCar;
    private List<GameObject> flyingHotDog = new List<GameObject>();

    void Start()
    {
        StartCoroutine(SpawnObject(delayAndSpawnRate));
    }

    IEnumerator SpawnObject(float firstDelay)
    {
        float spawnRateCountdown = timeUntilSpawnRateIncrease;
        float spawnCountdown = firstDelay;
        while (true)
        {
            yield return null;
            spawnRateCountdown -= Time.deltaTime;
            spawnCountdown -= Time.deltaTime;

            // Should a new object be spawned?
            if (spawnCountdown < 0)
            {
                spawnCountdown += delayAndSpawnRate;
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
            }

            // Should the spawn rate increase?
            if (spawnRateCountdown < 0 && delayAndSpawnRate > 1)
            {
                spawnRateCountdown += timeUntilSpawnRateIncrease;
                delayAndSpawnRate -= 0.1f;
            }
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
