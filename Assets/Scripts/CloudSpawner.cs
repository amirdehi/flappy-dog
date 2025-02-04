using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CloudSpawner : MonoBehaviour
{
    public Canvas canvas;
    public GameObject[] cloudPrefabs;
    public float minSpawnRate = 2f;
    public float maxSpawnRate = 5f;
    public float heightOffset = 800f;

    private float offsetX = 500f;
    private float timer = 0f;
    private float nextSpawnTime;
    private int lastCloud=0;

    void Start()
    {
        nextSpawnTime= Random.Range(minSpawnRate, maxSpawnRate);
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= nextSpawnTime) {
            SpawnCloud();
            timer = 0;
            nextSpawnTime = Random.Range(minSpawnRate, maxSpawnRate);
        }
    }

    void SpawnCloud()
    {
        GameObject cloud = cloudPrefabs[randomCloud()];

        float randomY = Random.Range(-heightOffset, heightOffset);
        
        Vector3 spawnPosition=new Vector3(transform.position.x,randomY,0);
        cloud = Instantiate(cloud, canvas.transform);
        
        RectTransform cloudRect= cloud.GetComponent<RectTransform>();
        cloudRect.anchoredPosition = new Vector2(offsetX, randomY);
    }

    int randomCloud()
    {
        // If there's only one obstacle, return it
        if (cloudPrefabs.Length == 1)
            return 0;

        int randomObstacle = 0;
        do
        {
            randomObstacle = Random.Range(0, cloudPrefabs.Length);
        } while (randomObstacle == lastCloud);

        lastCloud = randomObstacle;
        return randomObstacle;
    }
}
