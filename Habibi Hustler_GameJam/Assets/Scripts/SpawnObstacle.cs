using UnityEngine;

public class SpawnObstacle : MonoBehaviour
{
    public GameObject obstaclePrefab;
    public int maxObstacles = 2; // Max obstacles per tile
    float[] laneX = { -3f, 0f, 3f };

    void Start()
    {
        int obstacleCount = Random.Range(1, maxObstacles + 1);
        System.Collections.Generic.List<float> availableLanes = new System.Collections.Generic.List<float>(laneX);

        for (int i = 0; i < obstacleCount && availableLanes.Count > 0; i++)
        {
            int index = Random.Range(0, availableLanes.Count);
            float x = availableLanes[index];
            availableLanes.RemoveAt(index); // Don't reuse this lane

            float z = transform.position.z + Random.Range(10f, 25f);
            Vector3 spawnPosition = new Vector3(x, 0.5f, z);

            Instantiate(obstaclePrefab, spawnPosition, Quaternion.identity);
        }
    }

}
