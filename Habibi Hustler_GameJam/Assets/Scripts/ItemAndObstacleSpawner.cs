using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemAndObstacleSpawner : MonoBehaviour
{
    public GameObject[] itemPrefabs;       // Array of item prefabs
    public GameObject[] obstaclePrefabs;   // Array of obstacle prefabs

    public float yPosition = -5.553f;       // Fixed Y position
    public float[] zSlots = { -4.6f, -5.1f, -5.65f, -6.12f }; // Z-axis slot positions

    public float startX = -10f;             // Starting X position
    public float distanceBetweenSpawns = 5f; // Distance between spawns along X
    public int numberOfSpawns = 10;         // Total number of spawn points

    void Start()
    {
        SpawnItemsAndObstacles();
    }

    void SpawnItemsAndObstacles()
    {
        for (int i = 0; i < numberOfSpawns; i++)
        {
            float xPosition = startX - i * distanceBetweenSpawns;

            // Randomly pick one of the Z slots to place an item
            int itemSlotIndex = Random.Range(0, zSlots.Length);

            for (int z = 0; z < zSlots.Length; z++)
            {
                Vector3 spawnPosition = new Vector3(xPosition, yPosition, zSlots[z]);

                if (z == itemSlotIndex)
                {
                    // Spawn a random item
                    GameObject itemPrefab = itemPrefabs[Random.Range(0, itemPrefabs.Length)];
                    Instantiate(itemPrefab, spawnPosition, Quaternion.identity);
                }
                else
                {
                    // Randomly decide to spawn an obstacle or nothing (50% chance)
                    if (Random.value < 0.5f)
                    {
                        GameObject obstaclePrefab = obstaclePrefabs[Random.Range(0, obstaclePrefabs.Length)];
                        Instantiate(obstaclePrefab, spawnPosition, Quaternion.identity);
                    }
                    // else: do nothing
                }
            }
        }
    }
}
