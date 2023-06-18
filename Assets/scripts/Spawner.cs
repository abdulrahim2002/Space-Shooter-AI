using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject rockPrefab;
    public GameObject enemyPrefab;
    public GameObject playerPrefab;

    public float spawnInterval = 2f; // Time interval between spawning rocks and enemy spaceships
    public bool gameStarted = false;

    private float timer = 0f;

    void Start()
    {
        gameStarted = true;
        SpawnPlayer();
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= spawnInterval)
        {
            SpawnObject();
            timer = 0f;
        }
    }

    private void SpawnObject()
    {
        bool spawnRock = Random.value < 0.7f; // 50% chance to spawn a rock, 50% chance to spawn an enemy spaceship

        if (spawnRock)
        {
            SpawnRock();
        }
        else
        {
            SpawnEnemySpaceship();
        }
    }

    private void SpawnPlayer()
    {
        Vector3 spawnPosition = new Vector3(-8f, 0f , 0f);
        Instantiate(playerPrefab, spawnPosition, Quaternion.Euler(0f, 0f, -90f));
    }

    private void SpawnRock()
    {
        float randomY = Random.Range(-4.5f, 4.5f); // Random y position within the desired range
        Vector3 spawnPosition = new Vector3(10f, randomY, 0f);
        Instantiate(rockPrefab, spawnPosition, Quaternion.identity);
    }

    private void SpawnEnemySpaceship()
    {
        float randomY = Random.Range(-4.5f, 4.5f); // Random y position within the desired range
        Vector3 spawnPosition = new Vector3(10f, randomY, 0f);
        Instantiate(enemyPrefab, spawnPosition, Quaternion.Euler(0f, 0f, 90f));
    }
}




//generates rocks of random size

//private void SpawnRock()
//{
//    float randomY = Random.Range(-4.5f, 4.5f); // Random y position within the desired range
//    Vector3 spawnPosition = new Vector3(10f, randomY, 0f);

//    // Generate a random scale value between 1 and 1.3
//    float randomScale = Random.Range(0.7f, 1.3f);
//    Vector3 spawnScale = new Vector3(randomScale, randomScale, 1f);

//    // Instantiate the rock prefab with the random scale
//    GameObject rock = Instantiate(rockPrefab, spawnPosition, Quaternion.identity);
//    rock.transform.localScale = spawnScale;
//}