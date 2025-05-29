using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Environment_Spawner : MonoBehaviour
{
    public GameObject environmentPrefab;    // Assign your environment prefab in the Inspector
    public float startX = -15.7f;           // Initial X position
    public float spacing = -7f;             // X-axis spacing (negative for leftward generation)
    public float yPos = 5.29f;              // Fixed Y position
    public float zPos = -4.7f;              // Fixed Z position
    public int initialSpawnCount = 5;       // Number of environments to spawn at start
    public float spawnTriggerDistance = 30f; // Distance ahead of the player or camera to keep spawning

    private float lastXPosition;

    void Start()
    {
        lastXPosition = startX;

        // Spawn initial environment segments
        for (int i = 0; i < initialSpawnCount; i++)
        {
            SpawnEnvironment();
        }
    }

    void Update()
    {
        // Check if we need to spawn a new segment based on distance
        if (Camera.main.transform.position.x - lastXPosition < spawnTriggerDistance)
        {
            SpawnEnvironment();
        }
    }

    void SpawnEnvironment()
    {
        Vector3 spawnPos = new Vector3(lastXPosition, yPos, zPos);
        Instantiate(environmentPrefab, spawnPos, Quaternion.identity);
        lastXPosition += spacing;
    }
}
