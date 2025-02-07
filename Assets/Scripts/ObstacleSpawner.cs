using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    public Canvas canvas;
    public GameObject[] obstaclePrefabs;
    public float minSpawnRate = 1f;
    public float maxSpawnRate = 3f;
    public float heightOffset = 800f;

    private float offsetX = 700f;
    private float timer = 0f;
    private float nextSpawnTime;
    private int lastObstacle=0;

    void Start()
    {
        nextSpawnTime= Random.Range(minSpawnRate, maxSpawnRate);
    }

    void Update()
    {
        if (GameManager.isGameRunning)
        {
            timer += Time.deltaTime;
            if (timer >= nextSpawnTime)
            {
                SpawnObstacle();
                timer = 0;
                nextSpawnTime = Random.Range(minSpawnRate, maxSpawnRate);
            }
        }
        else
        {
            timer = 0;
        }
    }

    void SpawnObstacle()
    {
        GameObject obstacle = obstaclePrefabs[randomObstacle()];

        float randomY = Random.Range(-heightOffset, heightOffset);
        
        Vector3 spawnPosition=new Vector3(transform.position.x,randomY,0);
        obstacle = Instantiate(obstacle, canvas.transform);
        
        RectTransform obstacleRect= obstacle.GetComponent<RectTransform>();
        obstacleRect.anchoredPosition = new Vector2(offsetX, randomY);
    }

    int randomObstacle()
    {
        // If there's only one obstacle, return it
        if (obstaclePrefabs.Length == 1)
            return 0;

        int randomObstacle = 0;
        do
        {
            randomObstacle = Random.Range(0, obstaclePrefabs.Length);
        } while (randomObstacle == lastObstacle);

        lastObstacle = randomObstacle;
        return randomObstacle;
    }
}
