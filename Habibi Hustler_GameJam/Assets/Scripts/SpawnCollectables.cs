using UnityEngine;

public class SpawnCollectables : MonoBehaviour
{
    public GameObject applePrefab;
    public GameObject datePrefab;
    float[] laneX = { -3f, 0f, 3f };

    void Start()
    {
        int collectableCount = Random.Range(1, 4); // 1 to 3 collectables

        for (int i = 0; i < collectableCount; i++)
        {
            float x = laneX[Random.Range(0, laneX.Length)];
            float z = transform.position.z + Random.Range(5f, 25f);
            Vector3 pos = new Vector3(x, 0.5f, z);

            GameObject prefabToSpawn = Random.value > 0.5f ? applePrefab : datePrefab;

            Instantiate(prefabToSpawn, pos, Quaternion.identity);
        }
    }
}
